using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Services
{
    public class CheckoutService
    {
        private ItemService _itemService = new ItemService();

        #region PropertyBags
        private ShoppingCartPropertyBag _shoppingCart;
        public ShoppingCartPropertyBag ShoppingCart
        {
            get
            {
                if (_shoppingCart == null)
                {
                    _shoppingCart = PropertyBagService.Get<ShoppingCartPropertyBag>(Settings.Company.CookieName + "_ShoppingCart");
                }
                return _shoppingCart;
            }
        }
        private CheckoutPropertyBag _checkoutPropertyBag;
        public CheckoutPropertyBag CheckoutPropertyBag
        {
            get
            {
                if (_checkoutPropertyBag == null)
                {
                    _checkoutPropertyBag = PropertyBagService.Get<CheckoutPropertyBag>(Settings.Company.CookieName + "_CheckoutPropertyBag");
                }
                return _checkoutPropertyBag;
            }
        }
        public void ValidatePropertyBags(CheckoutFlowType type)
        {
            if(CheckoutPropertyBag.FlowType != type)
            {
                PropertyBagService.Delete(CheckoutPropertyBag);
                CheckoutPropertyBag.FlowType = type;
                PropertyBagService.Update(CheckoutPropertyBag);
            }
            if(ShoppingCart.FlowType != type)
            {
                PropertyBagService.Delete(ShoppingCart);
                ShoppingCart.FlowType = type;
                PropertyBagService.Update(ShoppingCart);
            }
        }
        #endregion

        #region Order Calculation
        public CRMOrderCalcContract CalculateOrder(IOrderConfiguration orderConfiguration)
        {
            var i = 1;
            ShoppingCart.OrderItems.ForEach(c => { c.OrderLineNumber = i; i++; });
            var Items = ShoppingCart.OrderItems.Select(c => new CRMOrderCalcRequestDetailContract
            {
                ItemId = c.ItemId,
                ItemCode = c.ItemCode,
                Quantity = c.Quantity,
                OrderLineNumber = c.OrderLineNumber
            });

            var request = CheckoutPropertyBag.Order;
            request.Details = Items;
            request.PriceType = orderConfiguration.PriceTypeID;
            request.CurrencyCode = GlobalUtilities.Globalization.GetSelectedMaret().CurrencyCode;
            request.Country = GlobalUtilities.Globalization.GetSelectedCountryCode();
            request.CompanyId = Settings.API.CompanyId;
            request.ReturnAllShipMethods = true;
            request.OrderType = 1;
            request.OrderStatusType = 1;
            request.StorefrontId = 1;
            var response = Teqnavi.ServiceContext().CalculateCrmOrder(request);
            ShoppingCart.CalculatedOrder = response.Data;
            PropertyBagService.Update(ShoppingCart);
            return response.Data.CrmOrder;
        }
        #endregion

        #region Cart
        public CartModel GetShoppingCart(IOrderConfiguration orderConfiguration, IOrderConfiguration autoOrderConfiguration, bool reCalculate = false)
        {
            //And need to figure out a good way to handle the items so they dont need to get pulled more then once
            var cart = new CartModel();
            List<Item> items = new List<Item>();
            if (ShoppingCart.OrderItems.Count() == 0)
            {

            }
            else if (reCalculate)
            {
                //var calculatedOrder = CalculateOrder(orderConfiguration);
                //items = _itemService.GetItems(new ItemRequest(orderConfiguration, calculatedOrder.Details.Select(c => c.ItemId).ToList())).ToList();
                //items.ForEach(f =>
                //{
                //    f.Quantity = calculatedOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity;
                //    f.ItemPrice.ItemPrice = calculatedOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).ItemPrice;
                //});
                //cart.Order.Items = items;
                //cart.Order.Tax = calculatedOrder.TaxTotal;
                //cart.Order.Shipping = calculatedOrder.ShippingTotal;

                //Just for now
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, ShoppingCart.OrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.Order.Items = items;
            }
            else if( ShoppingCart.CalculatedOrder != null && ShoppingCart.CalculatedOrder.CrmOrder.Details != null)
            {
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, ShoppingCart.CalculatedOrder.CrmOrder.Details.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f =>
                {
                    f.Quantity = ShoppingCart.CalculatedOrder.CrmOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity;
                    f.ItemPrice.ItemPrice = ShoppingCart.CalculatedOrder.CrmOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).ItemPrice;
                });
                cart.Order.Items = items;
                cart.Order.Tax = ShoppingCart.CalculatedOrder.CrmOrder.TaxTotal;
                cart.Order.Shipping = ShoppingCart.CalculatedOrder.CrmOrder.ShippingTotal;
            }
            else
            {
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, ShoppingCart.OrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.Order.Items = items;
            }
            if (ShoppingCart.AutoOrderItems.Count() == 0)
            {

            }
            else
            {
                items = _itemService.GetItems(new ItemRequest(autoOrderConfiguration, ShoppingCart.AutoOrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.AutoOrder.Items = items;
            }
            return cart;
        }
        #endregion

        #region SubMitCheckout
        public SubmitCheckoutnResponse SubmitCheckout(CheckoutFlowType type)
        {
            return new SubmitCheckoutnResponse
            {
                Success = true,
                Message = ""
            };
        }
        #endregion
    }
    public class SubmitCheckoutnResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}