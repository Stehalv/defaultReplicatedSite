using DefaultReplicatedSite.Models;
using LibraryCommon;
using System.Collections.Generic;
using MakoLibrary.Contracts;
using System.Linq;
using DefaultReplicatedSite.Services;

namespace DefaultReplicatedSite.Services
{
    public class Cart
    {
        public int OrderID { get; set; }
        public List<Item> Items { get; set; }
        public int ShipMethodID { get; set; }
        public decimal SubTotal
        {
            get
            {
                if (Items != null)
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