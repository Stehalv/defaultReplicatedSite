using DefaultReplicatedSite.Models;
using LibraryCommon;
using MakoLibrary.Contracts;
using MakoLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class ItemService
    {
        public MakoService context = Teqnavi.ServiceContext();
        public List<Item> GetItems(ItemRequest request)
        {
            var items = new List<ItemContract>();
            if(request.WebCaegoryID != 0)
                items = context.GetWebCategoryItems(request.WebCaegoryID, new LibraryCommon.MakoFilterQueryContract()).Data.ToList();
            else
            {
                var filter = new MakoFilterQueryContract();
                
                items = context.GetItems(filter).Data.ToList();
                if(request.ItemIds != null)
                {
                    items = items.Where(c => request.ItemIds.Contains(c.ItemId)).ToList();
                }
            }
            
            return ConvertToItem(items, request);
        }
        public List<WebCategoryContract> GetWebCategories(WebCategoryRequest request)
        {
            var categories = context.GetWebCategories();
            return categories.Data.ToList();
        }
        private List<Item> ConvertToItem(List<ItemContract> items, ItemRequest request)
        {
            List<Item> list = new List<Item>();
            foreach (var item in items.Where(c => c.ItemPricing.Where(f => f.CountryCode == request.Configuration.CountryCode).Count() > 0))
            {
                var _item = new Item(item, request.Configuration);
                list.Add(_item);
            }
            return list;
        }
    }
}