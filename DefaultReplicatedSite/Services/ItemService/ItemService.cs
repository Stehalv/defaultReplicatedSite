using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
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
        public List<ProductModel> GetItems(ItemRequest request)
        {
            var items = new List<ItemContract>();
            if (request.WebCaegoryID != 0)
            {
                var response = context.GetWebCategoryItems(request.WebCaegoryID, new MakoFilterQueryContract());
                items = response.Data.ToList();
            }
            else if(request.SingleItemRequest)
            {
                var filter = new MakoFilterQueryContract();
                filter.SearchList = new List<MakoFilterSearchData>
                {
                    new MakoFilterSearchData
                    {
                        SearchFilter    = nameof(ItemContract.ItemId),
                        SearchMethod    = ApiQuery.SearchMethod.IsEqual,
                        SearchValue     = request.ItemId.ToString()
                    }
                };

                items = context.GetItems(filter).Data.ToList();
                if (request.ItemIds != null)
                {
                    items = items.Where(c => request.ItemIds.Contains(c.ItemId)).ToList();
                }
            }
            else
            {
                var filter = new MakoFilterQueryContract();
                
                items = context.GetItems(filter).Data.ToList();
                if(request.ItemIds != null)
                {
                    items = items.Where(c => request.ItemIds.Contains(c.ItemId)).ToList();
                }
            }
            return new ProductModel().ReturnCorrectTypeList(items, request);
        }
        public List<WebCategoryContract> GetWebCategories(WebCategoryRequest request)
        {
            var categories = context.GetWebCategories();
            return categories.Data.ToList();
        }
    }
}