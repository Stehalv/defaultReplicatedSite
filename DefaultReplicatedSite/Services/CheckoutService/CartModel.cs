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
            Order = new Cart();
            AutoOrder = new Cart();
        }
        public Cart Order { get; set; }
        public Cart AutoOrder { get; set; }
    }
}