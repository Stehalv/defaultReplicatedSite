using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class ShoppingFlow
    {
        private CheckoutService _checkoutService = new CheckoutService();
        public ShoppingFlow()
        {
            InformationStep = new InformationStep();
            ShippingStep = new ShippingStep();
            PaymentStep = new PaymentStep();
        }
        public bool HasShopping => true;
        public CheckoutSteps PreviousStep { get; set; }
        public CheckoutSteps CurrentStep { get; set; }
        public CheckoutSteps NextStep { get; set; }
        public List<CheckoutSteps> CheckoutStepList => new List<CheckoutSteps>
        {
            CheckoutSteps.Information, CheckoutSteps.Shipping, CheckoutSteps.Payment, CheckoutSteps.OrderCompleted
        };
        public InformationStep InformationStep { get; set; }
        public ShippingStep ShippingStep { get; set; }
        public PaymentStep PaymentStep { get; set; }
        public CartModel ShoppingCart { get; set; }
    }
}