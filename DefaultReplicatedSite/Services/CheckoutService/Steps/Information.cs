using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class InformationStep
    {
        private CheckoutService _service = new CheckoutService();
        public InformationStep()
        {
            Customer = _service.CustomerPropertyBag.Customer;
        }
        public CheckoutSteps Step => CheckoutSteps.Information;
        public CheckoutSteps CurrentStep { get; set; }
        public CheckoutSteps NextStep { get; set; }
        public bool RecalculateCart => false;
        public Customer Customer { get; set; }
        public void SubmitStep()
        {
            var CustomerPropertyBag = _service.CustomerPropertyBag;
            var CheckoutPropertyBag = _service.CheckoutPropertyBag;
            CustomerPropertyBag.Customer = Customer;
            CheckoutPropertyBag.Order.FirstName = CustomerPropertyBag.Customer.FirstName;
            CheckoutPropertyBag.Order.LastName = CustomerPropertyBag.Customer.LastName;
            CheckoutPropertyBag.Order.Address1 = CustomerPropertyBag.Customer.MailingAddress.Address1;
            CheckoutPropertyBag.Order.Address2 = CustomerPropertyBag.Customer.MailingAddress.Address2;
            CheckoutPropertyBag.Order.City = CustomerPropertyBag.Customer.MailingAddress.City;
            CheckoutPropertyBag.Order.State = CustomerPropertyBag.Customer.MailingAddress.RegionProvState;
            CheckoutPropertyBag.Order.Zip = CustomerPropertyBag.Customer.MailingAddress.PostalCode;
            CustomerPropertyBag.Customer.ShippingAddress = Customer.MailingAddress;
            PropertyBagService.Update(CheckoutPropertyBag);
            PropertyBagService.Update(CustomerPropertyBag);
        }
    }
}