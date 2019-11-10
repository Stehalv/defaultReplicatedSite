using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class CheckoutPropertyBag : BasePropertyBag
    {
        public CheckoutPropertyBag()
        {
            Order = new CRMCalculateOrderRequestContract();
            AutoOrder = new CRMCreateOrderRecurringContract();
            Customer = new Customer();
        }
        public CheckoutPropertyBag(IOrderConfiguration orderConfig, IOrderConfiguration autoOrderConfig)
        {
            Order = new CRMCalculateOrderRequestContract();
            Order.PriceType = orderConfig.PriceTypeID;
            AutoOrder = new CRMCreateOrderRecurringContract();
            AutoOrder.PriceType = autoOrderConfig.PriceTypeID;
            Customer = new Customer();
        }
        public Customer Customer { get; set; }
        public CRMCalculateOrderRequestContract Order { get; set; }
        public CRMCreateOrderRecurringContract AutoOrder { get; set; }
        public bool ShippingSameAsMailing { get; set; }
        public bool BillingSameAsMailing { get; set; }
        public bool AutoOrderSameAsMailing { get; set; }
        public CheckoutFlowType FlowType { get; set; }

    }
}