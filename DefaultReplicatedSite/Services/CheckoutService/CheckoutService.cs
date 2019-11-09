using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Services
{
    public class CheckoutService
    {
        #region PropertyBags
        private ShoppingCartPropertyBag _shoppingCart { get; set; }
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
        private CustomerPropertyBag _customerPropertyBag { get; set; }
        public CustomerPropertyBag CustomerPropertyBag
        {
            get
            {
                if (_customerPropertyBag == null)
                {
                    _customerPropertyBag = PropertyBagService.Get<CustomerPropertyBag>(Settings.Company.CookieName + "_customerPropertyBag");
                }
                return _customerPropertyBag;
            }
            set
            {
                _customerPropertyBag = value;
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
        #endregion


        private ItemService _itemService = new ItemService();
        public IFlow GetFlow(CheckoutFlowType type)
        {
            var interfaceType = typeof(IFlow);
            var all = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(x => x.GetTypes())
                .Where(x => interfaceType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .Select(x => Activator.CreateInstance(x) as IFlow);
            return all.FirstOrDefault(a => a.Flow == type);
        }
        public CRMOrderCalcResponseContract CalculateOrder(CRMCalculateOrderRequestContract model, IOrderConfiguration orderConfiguration)
        {
            return Teqnavi.ServiceContext().CalculateCrmOrder(model).Data;
        }
        public CartModel GetShoppingCart(IOrderConfiguration orderConfiguration, IOrderConfiguration autoOrderConfiguration, bool reCalculate)
        {
            var cart = new CartModel();
            List<Item> items = new List<Item>();
            if (ShoppingCart.OrderItems.Count() == 0)
            {
                return null;
            }
            else if (reCalculate)
            {
                //var calculatedOrder = CalculateOrder((List<>)ShoppingCart.OrderItems, orderConfiguration);
                //items = _itemService.GetItems(new ItemRequest(orderConfiguration, calculatedOrder.CrmOrder.Details.Select(c => c.ItemId).ToList())).ToList();
                //items.ForEach(f =>
                //{
                //    f.Quantity = calculatedOrder.CrmOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity;
                //    f.ItemPrice.ItemPrice = calculatedOrder.CrmOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).ItemPrice;
                //});
            }
            else
            {
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, ShoppingCart.OrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.Order.Items = items;
            }
            return cart;
        }
    }
}