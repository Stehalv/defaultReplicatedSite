using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class Order : IOrder
    {
        public int OrderID { get; set; }
        public List<Item> Items { get; set; }
        public int ShipMethodID { get; set; }
        public decimal SubTotal
        {
            get
            {
                if(Items != null)
                {
                    return Items.Sum(c => c.Quantity * c.ItemPrice.ItemPrice);
                }
                return 0;
            }
        }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total
        {
            get
            {
                return SubTotal + Shipping + Tax;
            }
        }
    }
}