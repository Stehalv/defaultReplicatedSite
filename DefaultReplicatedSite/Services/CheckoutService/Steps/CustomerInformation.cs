using DefaultReplicatedSite.Models;

namespace DefaultReplicatedSite.Services
{
    public class CustomerInformationStep
    {
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
        public void SubmitStep()
        {
            PropertyBag.Customer = Customer;
            PropertyBag.Order.FirstName = PropertyBag.Customer.FirstName;
            PropertyBag.Order.LastName = PropertyBag.Customer.LastName;
            PropertyBag.Order.Address1 = PropertyBag.Customer.MailingAddress.Address1;
            PropertyBag.Order.Address2 = PropertyBag.Customer.MailingAddress.Address2;
            PropertyBag.Order.City = PropertyBag.Customer.MailingAddress.City;
            PropertyBag.Order.State = PropertyBag.Customer.MailingAddress.RegionProvState;
            PropertyBag.Order.Zip = PropertyBag.Customer.MailingAddress.PostalCode;
            PropertyBag.Customer.ShippingAddress = Customer.MailingAddress;
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                PropertyBag.Customer.OtherAddress1 = Customer.MailingAddress;
            }
            PropertyBagService.Update(PropertyBag);
        }
    }
}