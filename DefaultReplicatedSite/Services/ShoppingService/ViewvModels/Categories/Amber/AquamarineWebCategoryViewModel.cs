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
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/KRISTALS_AQUAMARINE_2048x2048.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "Regarded as a stone of youth and happiness, and some held that aquamarine could bring victory in any conflict.";
            ShortDescriptionListItems = new List<string> {
                "Soothing irritated skin caused by shaving",
                "Cleansing and properly moisturizing male skin",
                "Refreshing and toning skin"
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/09/Men_s_Set_grande_products_page.jpg?w=600&ssl=1";
            Description = "<p>This gemstone has also been associated with courage, strength and residence.Ancient lore from some cultures also regarded aquamarine as a stone of youth and happiness, " +
                "and some held that aquamarine could bring victory in any conflict, whether on the battlefield or in a court of law. " +
                "Today, crystal enthusiasts prize aquamarine because they believe its energy opens up channels of clarity to allow for greater progress through life’s challenges. " +
                "They also see the stone as allowing for a conscious release of old, negative patterns, so aquamarine is regarded as a stone of empowerment.</p>" +
                "<p>Applied to skincare, aquamarine appears to be helpful in calming irritation and in managing conditions like eczema and psoriasis.Because of its association with strength, " +
                "here at Kristals we chose to use aquamarine in the formulation of our men’s product line.</p>";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Aquamarine_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "Razor bumps and irritation are a concern",
                "Need help in keeping your skin properly moisturized",
                "Keeping skin healthy and revitalized is a priority"
            };
            CharacteristicsImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_358164647.jpg?w=760&ssl=1";
            SymboslismText = "The Sumerians, Egyptians and Hebrews held Aquamarine as a symbol of happiness and everlasting youth. It is held in quite high regard in the East as the Stone of the Seer and Mystic, a gemstone that imparts purity to the wearer.";
            MoodText = "The moods most often associated with aquamarine are soothing, cleansing, refreshing and invigorating. Aquamarine is also connected to psychic abilities, peace, courage, communication and purification.";
            ColorAndCharacterText = "Blue, very slightly greenish blue, greenish blue, very strongly greenish blue, or green-blue.";
            ElementText = "Water, as it offers cleansing, healing, and cooling properties.";
        }
    }
}