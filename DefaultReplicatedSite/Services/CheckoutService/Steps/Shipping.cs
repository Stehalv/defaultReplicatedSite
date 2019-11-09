using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class ShippingStep
    {
        private CheckoutService _service = new CheckoutService();
        public CheckoutSteps Step => CheckoutSteps.Shipping;
        public CheckoutSteps CurrentStep { get; set; }
        public CheckoutSteps NextStep { get; set; }
        public bool RecalculateCart => true;
        public bool HasOrder { get; set; }
        public bool HasAutoOrder { get; set; }
        public List<CRMOrderCalcShipMethodContract> ShipMethods { get; set; }
        public bool ShippingSameAsAccount { get; set; }
        public CRMExtendedAddress ShippingAddress { get; set; }
        public bool AutoOrderSameAsAccount { get; set; }
        public CRMExtendedAddress AutoOrderAddress { get; set; }
        public void SubmitStep()
        { 
            var CustomerPropertyBag = _service.CustomerPropertyBag;
            var CheckoutPropertyBag = _service.CheckoutPropertyBag;
            CheckoutPropertyBag.Order.Address1 = ShippingAddress.Address1;
            CheckoutPropertyBag.Order.Address2 = ShippingAddress.Address2;
            CheckoutPropertyBag.Order.City = ShippingAddress.City;
            CheckoutPropertyBag.Order.State = ShippingAddress.RegionProvState;
            CheckoutPropertyBag.Order.Zip = ShippingAddress.PostalCode;
            CustomerPropertyBag.Customer.ShippingAddress = ShippingAddress;
            PropertyBagService.Update(CheckoutPropertyBag);
            PropertyBagService.Update(CustomerPropertyBag);
        }
    }
}