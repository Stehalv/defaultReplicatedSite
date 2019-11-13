using DefaultReplicatedSite.Models;

namespace DefaultReplicatedSite.Services
{
    public class CustomerInformationStep
    {
        /// <summary>
        /// Fils the customermodel for the customerinfo step
        /// </summary>
        /// <param name="type">What flow are you using this for</param>
        /// <param name="previousStep">Where were you coming from</param>
        /// <param name="propertyBag">Propertybag to set the customer</param>
        public CustomerInformationStep(CheckoutFlowType type, CheckoutSteps previousStep, CheckoutPropertyBag propertyBag)
        {
            Type = type;
            PreviousStep = previousStep;
            PropertyBag = propertyBag;
            Customer = PropertyBag.Customer;
        }
        public CheckoutSteps Step => CheckoutSteps.CustomerInformation;
        public CheckoutSteps PreviousStep { get; set; }
        public CheckoutFlowType Type { get; set; }
        public CheckoutPropertyBag PropertyBag { get; set; }
        public bool RecalculateCart => false;
        public Customer Customer { get; set; }
        /// <summary>
        /// Sets the Customer mailing address, and adds the same info to the order.
        /// Todo: Need to add Complete() function to the address, so we can check if it is allready set. If Shipping address is set skip setting the fields on the order
        /// </summary>
        public void SubmitStep()
        {
            PropertyBag.Customer = Customer;
            if (Type == CheckoutFlowType.SimpleEnrollment)
            {
                PropertyBag.BillingSameAsMailing = true;
                PropertyBag.ShippingSameAsMailing = true;
                PropertyBag.AutoOrderSameAsMailing = true;
            }
            PropertyBagService.Update(PropertyBag);
            PropertyBagService.Update(PropertyBag);
        }
    }
}