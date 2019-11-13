using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.Services;
using System.Collections.Generic;
using System.Linq;

namespace DefaultReplicatedSite.ViewModels
{
    public class EnrollmentFlow : IFlow
    {
        private CheckoutService _checkoutService = new CheckoutService();
        /// <summary>
        /// This is where all the logic for the Flow is placed. We create all models used in the flow, and make them ready.
        /// </summary>
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
        /// <summary>
        /// Calculates the previous step from the current
        /// </summary>
        public CheckoutSteps PreviousStep
        {
            get
            {
                var index = CheckoutStepList.FindIndex(c => c == CurrentStep);

                return (index > 0) ? CheckoutStepList[index - 1] : 0;
            }
        }
        /// <summary>
        /// Calculates the next step from the current
        /// </summary>
        public CheckoutSteps NextStep
        {
            get
            {
                var index = CheckoutStepList.FindIndex(c => c == CurrentStep);
                return (index != CheckoutStepList.Count() -1) ? CheckoutStepList[index + 1] : 0;
            }
        }
        /// <summary>
        /// List of all steps, needs to be in order of appearance
        /// </summary>
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