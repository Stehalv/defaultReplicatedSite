using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models.Checkout
{
    public class ShoppingCartItem : IShoppingCartItem
    {
        public string ItemCode { get; set; }
        public string Quantity { get; set; }
    }
}