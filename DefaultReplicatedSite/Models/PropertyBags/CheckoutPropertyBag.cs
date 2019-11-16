using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using System;

namespace DefaultReplicatedSite.Models
{
    public class CheckoutPropertyBag : BasePropertyBag
    {
        public CheckoutPropertyBag()
        {
            Customer = new Customer();
            EnrollerID = Convert.ToInt64(Identity.Owner.CustomerId);
            ShippingSameAsMailing = true;
            BillingSameAsMailing = true;
            AutoOrderSameAsMailing = true;
        }
        public Customer Customer { get; set; }
        public bool ShippingSameAsMailing { get; set; }
        public bool BillingSameAsMailing { get; set; }
        public long EnrollerID {get; set;}
        public bool AutoOrderSameAsMailing { get; set; }
        public CheckoutFlowType FlowType { get; set; }
        public CheckoutResponse Response { get; set; }

    }
}