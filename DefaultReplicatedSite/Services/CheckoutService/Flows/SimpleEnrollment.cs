using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class SimpleEnrollmentFlow : IFlow
    {
        private CheckoutService _checkoutService = new CheckoutService();
        public SimpleEnrollmentFlow()
        {
            InformationStep = new CustomerInformationStep(
                CheckoutFlowType.SimpleEnrollment, 
                CheckoutSteps.ShoppingCart, 
                _checkoutService.CheckoutPropertyBag
                );
            CheckoutCompleteStep = new CompleteCheckoutStep(
                CheckoutFlowType.SimpleEnrollment,
                _checkoutService.CheckoutPropertyBag, 
                _checkoutService.ShoppingCart
                );
        }
        public bool HasShopping => true;
        public CheckoutFlowType Type => CheckoutFlowType.SimpleEnrollment;
        public CheckoutSteps CurrentStep { get; set; }
        public CheckoutSteps PreviousStep
        {
            get
            {
                var index = CheckoutStepList.FindIndex(c => c == CurrentStep);

                return (index > 0) ? CheckoutStepList[index - 1] : 0;
            }
        }
        public CheckoutSteps NextStep
        {
            get
            {
                var index = CheckoutStepList.FindIndex(c => c == CurrentStep);
                return (index != CheckoutStepList.Count() - 1) ? CheckoutStepList[index + 1] : 0;
            }
        }
        public List<CheckoutSteps> CheckoutStepList => new List<CheckoutSteps>
        {
            CheckoutSteps.CustomerInformation,  
            CheckoutSteps.CompleteCheckout
        };
        public CustomerInformationStep InformationStep { get; set; }
        public CompleteCheckoutStep CheckoutCompleteStep { get; set;}
    }
}