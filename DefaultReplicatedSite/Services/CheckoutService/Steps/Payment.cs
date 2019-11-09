﻿using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class PaymentStep
    {
        private CheckoutService _service = new CheckoutService();
        public CheckoutSteps Step => CheckoutSteps.Payment;
        public CheckoutSteps CurrentStep { get; set; }
        public CheckoutSteps NextStep { get; set; }
        public bool RecalculateCart => false;
        public bool HasOrder { get; set; }
        public bool HasAutoOrder { get; set; }
        public bool BillingSameAsAccount { get; set; }
        public CRMExtendedAddress BillingAddress { get; set; }

        public void SubmitStep()
        {
            var CheckoutPropertyBag = _service.CheckoutPropertyBag;
            PropertyBagService.Update(CheckoutPropertyBag);
        }
    }
}