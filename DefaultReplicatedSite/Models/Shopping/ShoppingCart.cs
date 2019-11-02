using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models.Checkout
{
    public class ShoppingCart : IShoppingCart
    {
        public IEnumerable<IShoppingCartItem> OrderItems { get; set; }
        public IEnumerable<IShoppingCartItem> AutoOrderItems { get; set; }
    }
}