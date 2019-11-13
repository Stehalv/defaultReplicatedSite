using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class PaymentStep
    {
        /// <summary>
        /// Fills the payment model so it is ready to be used
        /// Todo: need to add paymentmethods and handle token creation
        /// </summary>
        /// <param name="type">What flow are you using this step for?</param>
        /// <param name="previousStep">What step did you come from, needed for navigation</param>
        /// <param name="propertyBag">Need the propertybag to decide what info is allready set</param>
        public PaymentStep(CheckoutFlowType type, CheckoutSteps previousStep, CheckoutPropertyBag propertyBag)
        {
            Type = type;
            PreviousStep = previousStep;
            PropertyBag = propertyBag;
        }
        private CheckoutService _service = new CheckoutService();
        public CheckoutSteps Step => CheckoutSteps.Payment;
        public CheckoutSteps PreviousStep { get; set; }
        public CheckoutFlowType Type { get; set; }
        public CheckoutPropertyBag PropertyBag { get; set; }
        public bool RecalculateCart => false;
        public bool HasOrder { get; set; }
        public bool HasAutoOrder { get; set; }
        public bool BillingSameAsAccount { get; set; }
        public CreditCard Card { get; set; }
        public Address BillingAddress { get; set; }

        public void SubmitStep()
        {
            PropertyBag.BillingSameAsMailing = BillingSameAsAccount;
            if(!BillingSameAsAccount)
            {
                PropertyBag.Customer.BillingAddress = BillingAddress;
            }
            PropertyBagService.Update(PropertyBag);
        }
    }
}