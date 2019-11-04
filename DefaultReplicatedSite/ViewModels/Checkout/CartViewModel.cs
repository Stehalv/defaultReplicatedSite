using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class CartViewModel
    {
        public IShoppingCart ShoppingCart { get; set; }
        public Order Order { get; set; }
        public AutoOrder AutoOrder { get; set; }
    }
}