using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class CartModel
    {
        public CartModel()
        {
            Order = new Order();
            AutoOrder = new AutoOrder();
        }
        public Order Order { get; set; }
        public AutoOrder AutoOrder { get; set; }
        public CheckoutFlowType Type { get; set; }
        public bool HasAutoOrder
        {
            get
            {
                return (AutoOrder.Items != null && AutoOrder.Items.Count() > 0);
            }
        }
        public bool HasOrder
        {
            get
            {
                return (Order.Items != null && Order.Items.Count() > 0);
            }
        }
    }
}