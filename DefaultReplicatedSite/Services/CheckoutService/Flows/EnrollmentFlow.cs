using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using System.Collections.Generic;
using System.Linq;

namespace DefaultReplicatedSite.ViewModels
{
    public class EnrollmentFlow : IFlow
    {
        private CheckoutService _checkoutService = new CheckoutService();
        public EnrollmentFlow()
        {
            InformationStep = new CustomerInformationStep(
                CheckoutFlowType.Enrollment, 
                CheckoutSteps.ShoppingCart, 
                _checkoutService.CheckoutPropertyBag
                );
            ShippingStep = new ShippingStep(
                CheckoutFlowType.Enrollment, 
                CheckoutSteps.CustomerInformation,
                _checkoutService.CheckoutPropertyBag,
                _checkoutService.ShoppingCart
                );
            PaymentStep = new PaymentStep(
                CheckoutFlowType.Enrollment, 
                CheckoutSteps.Shipping,
                _checkoutService.CheckoutPropertyBag);
            CheckoutCompleteStep = new CompleteCheckoutStep(
                CheckoutFlowType.Enrollment,
                _checkoutService.CheckoutPropertyBag,
                _checkoutService.ShoppingCart
                );
        }
        public bool HasShopping => true;
        public CheckoutFlowType Type => CheckoutFlowType.Enrollment;
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
                return (index != CheckoutStepList.Count() -1) ? CheckoutStepList[index + 1] : 0;
            }
        }
        public List<CheckoutSteps> CheckoutStepList => new List<CheckoutSteps>
        {
            CheckoutSteps.ShoppingCart,
            CheckoutSteps.CustomerInformation, 
            CheckoutSteps.Shipping, 
            CheckoutSteps.Payment, 
            CheckoutSteps.CompleteCheckout
        };
        public CustomerInformationStep InformationStep { get; set; }
        public ShippingStep ShippingStep { get; set; }
        public PaymentStep PaymentStep { get; set; }
        public CompleteCheckoutStep CheckoutCompleteStep { get; set; }
        public CartModel ShoppingCart { get; set; }
    }
}