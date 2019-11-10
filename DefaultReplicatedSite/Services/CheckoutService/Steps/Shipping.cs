using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DefaultReplicatedSite.Services
{
    public class ShippingStep
    {
        public ShippingStep(CheckoutFlowType type, CheckoutSteps previousStep, CheckoutPropertyBag propertyBag, ShoppingCartPropertyBag shoppingCart)
        {
            Type = type;
            PreviousStep = previousStep;
            PropertyBag = propertyBag;
            ShoppingCart = shoppingCart;
            ShippingAddress = PropertyBag.Customer.ShippingAddress;
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                AutoOrderSameAsAccount = PropertyBag.AutoOrderSameAsMailing;
                AutoOrderAddress = propertyBag.Customer.OtherAddress1;
            }
            HasAutoOrder = ShoppingCart.AutoOrderItems.Count() > 0;
            ShippingSameAsAccount = PropertyBag.ShippingSameAsMailing;

        }
        public CheckoutSteps Step => CheckoutSteps.Shipping;
        public CheckoutSteps PreviousStep { get; set; }
        public CheckoutFlowType Type { get; set; }
        public CheckoutPropertyBag PropertyBag { get; set; }
        public ShoppingCartPropertyBag ShoppingCart { get; set; }
        public bool HasOrder { get; set; }
        public bool HasAutoOrder { get; set; }
        public List<CRMOrderCalcShipMethodContract> ShipMethods { get; set; }
        public bool ShippingSameAsAccount { get; set; }
        public CRMExtendedAddress ShippingAddress { get; set; }
        public bool AutoOrderSameAsAccount { get; set; }
        public CRMExtendedAddress AutoOrderAddress { get; set; }
        public void SubmitStep()
        {
            PropertyBag.ShippingSameAsMailing = ShippingSameAsAccount;
            if(!ShippingSameAsAccount)
            {
                PropertyBag.Order.Address1 = ShippingAddress.Address1;
                PropertyBag.Order.Address2 = ShippingAddress.Address2;
                PropertyBag.Order.City = ShippingAddress.City;
                PropertyBag.Order.State = ShippingAddress.RegionProvState;
                PropertyBag.Order.Zip = ShippingAddress.PostalCode;
                PropertyBag.Customer.ShippingAddress = ShippingAddress;
                PropertyBagService.Update(PropertyBag);
            }
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                PropertyBag.AutoOrderSameAsMailing = AutoOrderSameAsAccount;
                if (!AutoOrderSameAsAccount)
                {
                    PropertyBag.AutoOrder.Address1 = AutoOrderAddress.Address1;
                    PropertyBag.AutoOrder.Address2 = AutoOrderAddress.Address2;
                    PropertyBag.AutoOrder.City = AutoOrderAddress.City;
                    PropertyBag.AutoOrder.State = AutoOrderAddress.RegionProvState;
                    PropertyBag.AutoOrder.Zip = AutoOrderAddress.PostalCode;
                    PropertyBag.Customer.OtherAddress1 = AutoOrderAddress;
                    PropertyBagService.Update(PropertyBag);
                }
            }
        }
    }
}