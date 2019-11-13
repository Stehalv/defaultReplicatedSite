using DefaultReplicatedSite.Models;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class ShoppingCartItemCollection : List<ShoppingCartItem>
    {
        public void Add(IShoppingCartItem item)
        {
            var newItem = new ShoppingCartItem(item);
            // Don't process items with no quantities
            if (newItem.Quantity == 0) return;
            newItem.OrderLineNumber = this.Count() + 1;
            // Get a list of all items that have the same item code and type.
            var preExistingItems = this.FindAll(i =>
                  i.ItemId == newItem.ItemId);

            // If we returned any existing items that match the item code and type, we need to add to those existing items.
            if (preExistingItems.Count() > 0)
            {
                // Loop through each item found.
                preExistingItems.ForEach(i =>
                {
                    // Add the new quantity to the existing item code.
                    // Note that the only thing we are adding to the existing item code is the new quantity.
                    i.Quantity = i.Quantity + newItem.Quantity;
                });
            }

            // If we didn't find any existing items matching the item code or type, let's add it to the ShoppingBasketItemsCollection
            else
            {
                base.Add(newItem);
            }
        }

        public void Update(int id, decimal quantity)
        {
            var item = this.Where(c => c.ItemId == id).FirstOrDefault();
            if (item == null) return;

            // Remove the item if it is an invalid quantity
            if (quantity > 0)
            {
                item.Quantity = quantity;
            }
            else
            {
                this.Remove(item.ItemId);
            }
        }
        public void Update(ShoppingCartItem item)
        {
            var oldItem = this.Where(c => c.ID == item.ID).FirstOrDefault();
            if (oldItem == null) return;

            // Remove the old item
            this.Remove(oldItem.ItemId);

            // If we have a valid quantity, add the new item
            if (item.Quantity > 0)
            {
                this.Add(item);
            }
        }

        public void Remove(int id)
        {
            var matchingItems = this.Where(item => item.ItemId == id).ToList();
            foreach (var item in matchingItems)
            {
                base.Remove(item);
            }

        }

    }
}