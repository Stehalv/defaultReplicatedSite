using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class Item
    {
        public string ItemCode { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string ItemDescription { get; set; }
        public string ShortDetail1 { get; set; }
        public string ItemImage { get; set; }

    }
}