using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class ShoppingCartPropertyBag : BasePropertyBag
    {
        public ShoppingCartPropertyBag()
        {
            OrderItems = new ShoppingCartItemCollection();
            AutoOrderItems = new ShoppingCartItemCollection();
        }
        public ShoppingCartItemCollection OrderItems { get; set; }
        public ShoppingCartItemCollection AutoOrderItems { get; set; }
        public IOrderConfiguration OrderConfiguration { get; set; }
        public IOrderConfiguration AutoOrderConfiguration { get; set; }
        public bool HasItems
        {
            get
            {
                return OrderItems.Count() > 0 || AutoOrderItems.Count() > 0;
            }
        }
        public CRMOrderCalcResponseContract CalculatedOrder { get; set; }
        public CheckoutFlowType FlowType { get; set; }

    }
}