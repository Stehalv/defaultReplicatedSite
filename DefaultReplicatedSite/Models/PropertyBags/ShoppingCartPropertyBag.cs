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
        public bool HasItems
        {
            get
            {
                return OrderItems.Count() > 0 || AutoOrderItems.Count() > 0;
            }
        }
    }
}