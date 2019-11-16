using DefaultReplicatedSite.Services;
using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class ProductModel
    {
        public int ItemId { get; set; }
        public string ItemCode { get; set; }
        public int WebCategoryID { get; set; }
        public decimal Quantity { get; set; }
        public int PriceType { get; set; }
        public decimal StoreFrontPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal PreferredPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal CalculatedPrice { get; set; }
        public int ItemType { get; set; }
        public string TinyImage { get; set; }
        public string SmallImage { get; set; }
        public string MediumImage { get; set; }
        public string LargeImage { get; set; }
        public string ItemDescription { get; set; }
        public string ShortDescription { get; set; }
        public string ItemProductInfo { get; set; }
        public string HowToUse { get; set; }
        public string Ingredients { get; set; }
        public string CategoryKey { get; set; }
        public string PageHeaderImage
        {
            get
            {
                if(WebCategoryID != 0)
                {
                    return new ShoppingService().GetAllCategories().FirstOrDefault(c => c.WebCategoryID == WebCategoryID).HeaderImageUrl;
                }
                return "";
            }
        }

        public decimal Price
        {
            get
            {
                switch(PriceType)
                {
                    case (int)PriceTypes.StoreFront:
                        return StoreFrontPrice;
                    case (int)PriceTypes.Wholesale:
                        return WholesalePrice;
                    default:
                        return RetailPrice;
                }
            }
        }
        public decimal TotalPrice
        {
            get
            {
                return CalculatedPrice * Quantity;
            }
        }
        public List<ProductModel> ReturnCorrectTypeList(List<ItemContract> items, ItemRequest request)
        {
            return items.Select(c => new ProductModel
            {
                ItemCode = c.ItemCode,
                ItemId = c.ItemId,
                WebCategoryID = (request.WebCaegoryID != 0) ? request.WebCaegoryID : c.WebCategories.FirstOrDefault().WebCategoryId,
                PriceType = request.Configuration.PriceTypeID,
                ItemType = c.ItemType.Value,
                ItemDescription = c.Title,
                Quantity = 1,
                StoreFrontPrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.StoreFront).ItemPrice,
                RetailPrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.Retail).ItemPrice,
                WholesalePrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.Wholesale).ItemPrice,
                ShortDescription = c.Descr,
                SmallImage = c.SmallImage,
                MediumImage = c.MediumImage,
                LargeImage = c.LargeImage,
                TinyImage = c.TinyImage
            }).ToList();
        }
        public void GetItem(ItemContract item, ItemRequest request)
        {
            var c = item;
            ItemCode = c.ItemCode;
            ItemId = c.ItemId;
            WebCategoryID = c.WebCategories.FirstOrDefault().WebCategoryId;
            PriceType = request.Configuration.PriceTypeID;
            ItemType = c.ItemType.Value;
            ItemDescription = c.Title;
            Quantity = 1;
            RetailPrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.Retail).ItemPrice;
            StoreFrontPrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.StoreFront).ItemPrice;
            WholesalePrice = c.ItemPricing.FirstOrDefault(x => x.PriceType == (int)PriceTypes.Wholesale).ItemPrice;
            ShortDescription = c.ShortDescr;
            SmallImage = c.SmallImage;
            MediumImage = c.MediumImage;
            LargeImage = c.LargeImage;
            TinyImage = c.TinyImage;
        }
    }
}