using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace DefaultReplicatedSite.ViewModels
{
    public class WebCategoryViewModel : IWebCategoryViewModel
    {
        public WebCategoryViewModel()
        {

        }
        public int WebCategoryID { get; set; }
        public string ItemCode { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public List<ProductModel> Items { get; set; }
        public ProductModel KitItem
        {
            get
            {
                if(Items != null && Items.Count() > 0)
                {
                    return (Items.FirstOrDefault(c => c.ItemType == ItemTypes.StaticKit) ?? new ProductModel());
                }
                return new ProductModel();
            }
        }
        public int ProductLineId { get; set; }
        public string ProductLineImageUrl { get; set; }
        public string HeaderImageUrl { get; set; }
        public string ShortDescription { get; set; }
        public List<string> ShortDescriptionListItems { get; set; }
        public string ShortDescriptionImage { get; set; }
        public string Description { get; set; }
        public string DescriptionImageUrl { get; set; }
        public List<string> MatchList { get; set; }
        public string CharacteristicsImageUrl { get; set; }
        public string SymboslismText { get; set; }
        public string MoodText { get; set; }
        public string ColorAndCharacterText { get; set; }
        public string ElementText { get; set; }
    } 
}