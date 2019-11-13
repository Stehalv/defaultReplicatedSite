﻿using MakoLibrary.Contracts;
using System;

namespace DefaultReplicatedSite.Models
{
    public class ShoppingCartItem : CRMOrderCalcDetailContract, IShoppingCartItem
    {
        public ShoppingCartItem()
        {
            ID = Guid.NewGuid();
            ItemId = 0;
            ItemCode = string.Empty;
            Quantity = 0;
            OrderLineNumber = 0;
        }
        public ShoppingCartItem(IShoppingCartItem item)
        {
            ID = (item.ID != Guid.Empty) ? item.ID : Guid.NewGuid();
            ItemId = item.ItemId;
            ItemCode = item.ItemCode;
            Quantity = item.Quantity;
            OrderLineNumber = item.OrderLineNumber;
        }
        public Guid ID { get; set; }
        public string Title { get; set; }
    }
}