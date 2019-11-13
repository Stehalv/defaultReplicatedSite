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
        //All propertybag handling is put in the service. 
        //Todo: decide if ShoppingController should use this as well.
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
        /// <summary>
        /// Use to validate if the Propertybags are started in a different flow when entering the checkout of a flow.
        /// </summary>
        /// <param name="type">ChekcoutFlowType</param>
        /// <returns>True if correct flow for propertybags</returns>
        public bool ValidatePropertyBags(CheckoutFlowType type)
        {
            var result = true;
            if(ShoppingCart.FlowType != type)
            {
                PropertyBagService.Delete(ShoppingCart);
                PropertyBagService.Delete(CheckoutPropertyBag);
                CheckoutPropertyBag.FlowType = type;
                ShoppingCart.FlowType = type;
                PropertyBagService.Update(ShoppingCart);
                PropertyBagService.Update(CheckoutPropertyBag);
                result = false;
            }
            return result;
        }
        #endregion

        #region Order Calculation
        /// <summary>
        /// Calculate the order in the Mako engine.
        /// Todo: handle errors
        /// </summary>
        /// <param name="orderConfiguration"></param>
        /// <returns></returns>
        public CRMOrderCalcContract CalculateOrder(IOrderConfiguration orderConfiguration)
        {
            var response = Teqnavi.ServiceContext().CalculateCrmOrder(GetOrderRequest(orderConfiguration));
            //Set the calculated order in the shoppingcart propertybag to use if no recalculation is needed
            ShoppingCart.CalculatedOrder = response.Data;
            PropertyBagService.Update(ShoppingCart);
            //Return the calculated order
            return response.Data.CrmOrder;
        }
        private CRMCalculateOrderRequestContract GetOrderRequest(IOrderConfiguration orderConfiguration)
        {
            var i = 1;
            ShoppingCart.OrderItems.ForEach(c => { c.OrderLineNumber = i; i++; });
            //Todo: maybe find a better way to solve the conversion of the type
            var Items = ShoppingCart.OrderItems.Select(c => new CRMOrderCalcRequestDetailContract
            {
                ItemId = c.ItemId,
                ItemCode = c.ItemCode,
                Quantity = c.Quantity,
                OrderLineNumber = c.OrderLineNumber
            });
            //If no shippingaddress specified, use account address
            if (CheckoutPropertyBag.ShippingSameAsMailing)
                CheckoutPropertyBag.Customer.ShippingAddress = CheckoutPropertyBag.Customer.MailingAddress;
            //Set the ordercalc requestrequest
            return new CRMCalculateOrderRequestContract
            {
                FirstName = CheckoutPropertyBag.Customer.FirstName,
                LastName = CheckoutPropertyBag.Customer.LastName,
                Address1 = CheckoutPropertyBag.Customer.ShippingAddress.Address1,
                Address2 = CheckoutPropertyBag.Customer.ShippingAddress.Address2,
                City = CheckoutPropertyBag.Customer.ShippingAddress.City,
                State = CheckoutPropertyBag.Customer.ShippingAddress.RegionProvState,
                Zip = CheckoutPropertyBag.Customer.ShippingAddress.PostalCode,
                Details = Items,
                PriceType = orderConfiguration.PriceTypeID,
                CurrencyCode = GlobalUtilities.Globalization.GetSelectedMaret().CurrencyCode,
                Country = GlobalUtilities.Globalization.GetSelectedCountryCode(),
                CompanyId = Settings.API.CompanyId,
                ReturnAllShipMethods = true,
                OrderType = 1,
                OrderStatusType = 1,
                StorefrontId = 1
            };
        }
        #endregion

        #region Cart
        /// <summary>
        /// Gets the shopping cart based on 
        /// </summary>
        /// <param name="orderConfiguration">Specifications for the Order calculation</param>
        /// <param name="autoOrderConfiguration">Specifications for the autoorder calculation</param>
        /// <param name="reCalculate">Trigger recalculation of order</param>
        /// <returns>The model used in the shoppingcart</returns>
        public CartModel GetShoppingCart(IOrderConfiguration orderConfiguration, IOrderConfiguration autoOrderConfiguration, bool reCalculate = false)
        {
            //And need to figure out a good way to handle the items so they dont need to get pulled more then once
            var cart = new CartModel();

            ShoppingCart.OrderConfiguration = orderConfiguration;
            ShoppingCart.AutoOrderConfiguration = autoOrderConfiguration;
            PropertyBagService.Update(ShoppingCart);
            List<Item> items = new List<Item>();
            //If it is specified to recalculate the order, do it
            if (reCalculate)
            {

                //Todo: handle the calculated order and make it ready for the shoppingcart
                var calculatedOrder = CalculateOrder(orderConfiguration);
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, calculatedOrder.Details.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f =>
                {
                    f.Quantity = calculatedOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity;
                    f.ItemPrice.ItemPrice = calculatedOrder.Details.FirstOrDefault(x => x.ItemId == f.ItemId).ItemPrice;
                });
                cart.Order.Items = items;
                cart.Order.Tax = calculatedOrder.TaxTotal;
                cart.Order.Shipping = calculatedOrder.ShippingTotal;

            }
            //If Order is calculated, use that instead of the soppingcart propertybag
            else if( ShoppingCart.CalculatedOrder != null && ShoppingCart.CalculatedOrder.CrmOrder.Details != null)
            {
                //Todo: need to find a way to store the items, so we dont have to look them up every time
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
            //If none of the above, use the shoppingcart propertybag to create the shoppingcart model
            else
            {
                items = _itemService.GetItems(new ItemRequest(orderConfiguration, ShoppingCart.OrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.Order.Items = items;
            }
            //Todo: HAndle the autoOrder correctly, needs calculation?
            if (ShoppingCart.AutoOrderItems.Count() != 0)
            {
                items = _itemService.GetItems(new ItemRequest(autoOrderConfiguration, ShoppingCart.AutoOrderItems.Select(c => c.ItemId).ToList())).ToList();
                items.ForEach(f => f.Quantity = ShoppingCart.OrderItems.FirstOrDefault(x => x.ItemId == f.ItemId).Quantity);
                cart.AutoOrder.Items = items;
            }
            return cart;
        }
        #endregion

        #region SubMitCheckout
        //Todo: this need to get done when the API authentication is fixed
        public Response SubmitCheckout(CheckoutFlowType type)
        {
            var orderConfiguration = ShoppingCart.OrderConfiguration;
            var autoOrderConfiguration = ShoppingCart.OrderConfiguration;
            var createCustomer = (Identity.Customer == null || type == CheckoutFlowType.Enrollment || type == CheckoutFlowType.SimpleEnrollment);
            var autoOrder = new CRMCreateOrderRecurringContract();
            if (createCustomer)
            {

                if (CheckoutPropertyBag.ShippingSameAsMailing)
                {
                    CheckoutPropertyBag.Customer.ShippingAddress = CheckoutPropertyBag.Customer.MailingAddress;
                }
                if (CheckoutPropertyBag.BillingSameAsMailing)
                {
                    CheckoutPropertyBag.Customer.BillingAddress = CheckoutPropertyBag.Customer.MailingAddress;
                }
                if (CheckoutPropertyBag.AutoOrderSameAsMailing)
                {
                    CheckoutPropertyBag.Customer.AutoOrderAddress = CheckoutPropertyBag.Customer.MailingAddress;
                }
                var customer = CheckoutPropertyBag.Customer.ToCustomerCReate();
                customer.EnrollerId = CheckoutPropertyBag.EnrollerID;
                if (orderConfiguration == null && autoOrderConfiguration == null)
                {
                    var response = Teqnavi.ServiceContext().CreateCrmCustomer(customer);
                    //Todo: Set propertybagValues
                    return new Response
                    {
                        Success = response.Success,
                        Message = response.ErrorMessage
                    };
                }
                else
                {
                    var order = GetOrderRequest(orderConfiguration);
                    var request = new CRMTransactionRequestContract
                    {
                        CustomerRequest = customer,
                        AutoOrderRequest = autoOrder,
                        CalculateOrderRequest = order
                    };
                    var response = Teqnavi.ServiceContext().CreateTransactionRequest(request);

                    //Todo: Set propertybagValues
                    return new Response
                    {
                        Success = response.Success,
                        Message = response.ErrorMessage
                    };
                }
            }
            else 
            {
                var customerID = Convert.ToInt64(Identity.Customer.User.CustomerId);
                if (orderConfiguration != null)
                {
                    var order = GetOrderRequest(orderConfiguration);
                    order.CustomerId =customerID ;
                    var orderresponse = Teqnavi.ServiceContext().CreateCrmOrder(order);

                    //Todo: Set Propertybag  VAlues
                    if(!orderresponse.Success)
                        return new Response
                        {
                            Success = orderresponse.Success,
                            Message = orderresponse.ErrorMessage
                        };
                }
                if (autoOrderConfiguration != null && Identity.Customer != null)
                {
                    var autoOrderresponse = Teqnavi.ServiceContext().CreateOrderRecurringTemplate(customerID, autoOrder);
                    //Todo: Set Propertybag  VAlues
                    if (!autoOrderresponse.Success)
                        return new Response
                        {
                            Success = autoOrderresponse.Success,
                            Message = autoOrderresponse.ErrorMessage
                        };
                }

                return new Response
                {
                    Success = true,
                    Message = ""
                };
            }
        }
        #endregion

        #region Validations
        public bool IsTaxIDAvailable(string TaxId)
        {
            //Todo: need to add logiic for taxId check
            return true;
        }
        #endregion
    }
    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}