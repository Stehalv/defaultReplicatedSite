using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite.ViewModels
{
    public interface IWebCategoryViewModel
    {
        int WebCategoryID { get; set; }
        string Key { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        List<Item> Items { get; set; }
        Item KitItem { get; }
        int ProductLineId { get; set; }
        string ProductLineImageUrl { get; set; }
        string HeaderImageUrl { get; set; }
        string ShortDescription { get; set; }
        List<string> ShortDescriptionListItems { get; set; }
        string ShortDescriptionImage { get; set; }
        string Description { get; set; }
        string DescriptionImageUrl { get; set; }
        List<string> MatchList { get; set; }
        string CharacteristicsImageUrl { get; set; }
        string SymboslismText { get; set; }
        string MoodText { get; set; }
        string ColorAndCharacterText { get; set; }
        string ElementText { get; set; }
    }
}
