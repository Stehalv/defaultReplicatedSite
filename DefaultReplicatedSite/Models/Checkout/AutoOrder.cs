using System;
using System.Collections.Generic;
using System.Linq;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class AutoOrder :IOrder
    {
        public int OrderID { get; set; }
        public DateTime StartDate { get; set; }
        public List<ProductModel> Items { get; set; }
        public int ShipMethodID { get; set; }
        public decimal SubTotal
        {
            get
            {
                if (Items != null)
                {
                    return Items.Sum(c => c.Quantity * c.Price);
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
        public bool IsEditable { get; set; }
    }
}