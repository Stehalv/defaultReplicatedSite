using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace DefaultReplicatedSite.Services
{
    public class ShippingStep
    {
        /// <summary>
        /// Fills the model for the shippingstep so it is ready to be used
        /// </summary>
        /// <param name="type">What flow are you using it for?</param>
        /// <param name="previousStep">What step wre you coming from in this flow</param>
        /// <param name="propertyBag">We need the propertyabg to prepare the model</param>
        /// <param name="shoppingCart">We need the shoppingvcart info to prepare the model</param>
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
                AutoOrderAddress = propertyBag.Customer.AutoOrderAddress;
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
        public Address ShippingAddress { get; set; }
        public bool AutoOrderSameAsAccount { get; set; }
        public Address AutoOrderAddress { get; set; }
        /// <summary>
        /// Sets the shipping information for order and autoorder, and sets the corresponding addresses on the customer
        /// </summary>
        public void SubmitStep()
        {
            PropertyBag.ShippingSameAsMailing = ShippingSameAsAccount;
            if(!ShippingSameAsAccount)
            {
                PropertyBag.Customer.ShippingAddress = ShippingAddress;
            }
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                PropertyBag.AutoOrderSameAsMailing = AutoOrderSameAsAccount;
                if (!AutoOrderSameAsAccount)
                {
                    PropertyBag.Customer.AutoOrderAddress = AutoOrderAddress;
                }
            }
            PropertyBagService.Update(PropertyBag);
        }
    }
}