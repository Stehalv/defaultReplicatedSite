using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class AquamarineWebCategoryViewModel : WebCategoryViewModel
    {
        public AquamarineWebCategoryViewModel()
        {
            WebCategoryID = 1003;
            Key = "aquamarine";
            Name = "Aquamarine";
            Title = "Kristals Aquamarine";
            Items = new List<ProductModel>();
            ProductLineId = 1;
            ProductLineImageUrl = "/Content/Images/kristals_logo_black.jpg";
            HeaderImageUrl = "/Content/Images/KRISTALS_AQUAMARINE_2048x2048.jpg";
            ShortDescription = "Regarded as a stone of youth and happiness, and some held that aquamarine could bring victory in any conflict.";
            ShortDescriptionListItems = new List<string> {
                "Soothing irritated skin caused by shaving",
                "Cleansing and properly moisturizing male skin",
                "Refreshing and toning skin"
            };
            ShortDescriptionImage = "/Content/Images/Men_s_Set_grande_products_page.jpg";
            Description = "<p>This gemstone has also been associated with courage, strength and residence.Ancient lore from some cultures also regarded aquamarine as a stone of youth and happiness, " +
                "and some held that aquamarine could bring victory in any conflict, whether on the battlefield or in a court of law. " +
                "Today, crystal enthusiasts prize aquamarine because they believe its energy opens up channels of clarity to allow for greater progress through life’s challenges. " +
                "They also see the stone as allowing for a conscious release of old, negative patterns, so aquamarine is regarded as a stone of empowerment.</p>" +
                "<p>Applied to skincare, aquamarine appears to be helpful in calming irritation and in managing conditions like eczema and psoriasis.Because of its association with strength, " +
                "here at Kristals we chose to use aquamarine in the formulation of our men’s product line.</p>";
            DescriptionImageUrl = "/Content/Images/Aquamarine_B2.jpg";
            MatchList = new List<string> {
                "Razor bumps and irritation are a concern",
                "Need help in keeping your skin properly moisturized",
                "Keeping skin healthy and revitalized is a priority"
            };
            CharacteristicsImageUrl = "/Content/Images/shutterstock_358164647.jpg";
            SymboslismText = "The Sumerians, Egyptians and Hebrews held Aquamarine as a symbol of happiness and everlasting youth. It is held in quite high regard in the East as the Stone of the Seer and Mystic, a gemstone that imparts purity to the wearer.";
            MoodText = "The moods most often associated with aquamarine are soothing, cleansing, refreshing and invigorating. Aquamarine is also connected to psychic abilities, peace, courage, communication and purification.";
            ColorAndCharacterText = "Blue, very slightly greenish blue, greenish blue, very strongly greenish blue, or green-blue.";
            ElementText = "Water, as it offers cleansing, healing, and cooling properties.";
        }
    }
}