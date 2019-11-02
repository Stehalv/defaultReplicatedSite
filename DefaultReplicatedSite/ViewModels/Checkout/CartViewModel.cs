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
        public List<Item> OrderItems { get; set; }
        public List<Item> AutoOrderItems { get; set; }
    }
}