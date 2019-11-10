﻿using System;
using System.Collections.Generic;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class AutoOrder :IOrder
    {
        public int OrderID { get; set; }
        public DateTime StartDate { get; set; }
        public List<Item> Items { get; set; }
        public int ShipMethodID { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Shipping { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }
    }
}