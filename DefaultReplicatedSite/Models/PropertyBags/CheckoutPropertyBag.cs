using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class CheckoutPropertyBag : BasePropertyBag
    {
        public CheckoutPropertyBag()
        {
            Order = new CRMCalculateOrderRequestContract();
            AutoOrder = new CRMCreateOrderRecurringContract();
        }
        public CheckoutPropertyBag(IOrderConfiguration orderConfig, IOrderConfiguration autoOrderConfig)
        {
            Order = new CRMCalculateOrderRequestContract();
            Order.PriceType = orderConfig.PriceTypeID;
            AutoOrder = new CRMCreateOrderRecurringContract();
        }
        public CRMCalculateOrderRequestContract Order { get; set; }
        public CRMCreateOrderRecurringContract AutoOrder { get; set; }
    }
}