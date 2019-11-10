using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class CompleteCheckoutStep
    {
        public CompleteCheckoutStep(CheckoutFlowType type, CheckoutPropertyBag propertyBag, ShoppingCartPropertyBag shoppingCart, bool orderHandling = true)
        {
            Type = type;
            PropertyBag = propertyBag;
            ShoppingCart = shoppingCart;
            Customer = PropertyBag.Customer;
        }
        public CheckoutSteps Step => CheckoutSteps.CompleteCheckout;
        public CheckoutFlowType Type { get; set; }
        public bool OrderHandling { get; set; }
        public Customer Customer { get; set; }
        public CheckoutPropertyBag PropertyBag { get; set; }
        public ShoppingCartPropertyBag ShoppingCart { get; set; }

        public void SubmitStep()
        {
            //Handle Customer Registration
            if(OrderHandling)
            {
                //Handle order submition
            }
        }
    }
}