using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DefaultReplicatedSite.Services
{
    public class CompleteCheckoutStep
    {
        /// <summary>
        /// Final step of all flows. This is where we handle the customer registration and orders
        /// Todo: finish up teh Mako integration, and maybe add logic to verify the Propertybag info
        /// </summary>
        /// <param name="type">What flow are we completing</param>
        /// <param name="propertyBag"></param>
        /// <param name="shoppingCart"></param>
        /// <param name="orderHandling">Specify if there are orders in the flow, SimpleEnrollment will not have orders ie.</param>
        public CompleteCheckoutStep(CheckoutFlowType type, CheckoutPropertyBag propertyBag, ShoppingCartPropertyBag shoppingCart, IOrderConfiguration orderConfiguration = null, IOrderConfiguration autoOrderConfiguration = null)
        {
            Type = type;
            PropertyBag = propertyBag;
            ShoppingCart = shoppingCart;
            Customer = PropertyBag.Customer;
            OrderConfiguration = orderConfiguration;
            AutoOrderConfiguration = autoOrderConfiguration;
        }
        public CheckoutSteps Step => CheckoutSteps.CompleteCheckout;
        public CheckoutFlowType Type { get; set; }
        public bool OrderHandling { get; set; }
        public Customer Customer { get; set; }
        public CheckoutPropertyBag PropertyBag { get; set; }
        public IOrderConfiguration OrderConfiguration { get; set; }
        public IOrderConfiguration AutoOrderConfiguration { get; set; }
        public ShoppingCartPropertyBag ShoppingCart { get; set; }
        public CheckoutResponse Response { get; set; }
        /// <summary>
        /// Completes the flow, and adds all the records needed.
        /// </summary>
        public CheckoutResponse SubmitStep()
        {
            var response = new CheckoutService().SubmitCheckout(Type);
            return response;
        }
    }
}