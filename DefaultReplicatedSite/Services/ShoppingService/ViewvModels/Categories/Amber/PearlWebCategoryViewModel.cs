using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class PearlWebCategoryViewModel : WebCategoryViewModel
    {
        public PearlWebCategoryViewModel()
        {
            WebCategoryID = 1007;
            Key = "pearl";
            Name = "Pearl";
            Title = "Kristals Pearl";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/PEARLSS_2048x2048-2.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "For millennia, it’s been a symbol of purity, refinement and wealth, and also as a vehicle for channeling wisdom.";
            ShortDescriptionListItems = new List<string> {
                "Controlling oily skin while retaining much-needed moisture",
                "Helping maintain skin elasticity and flexibility",
                "Working in concert with antioxidants to fight free radicals for an anti-aging effect"
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/kri-prl-set_grande.jpg?w=760&ssl=1";
            Description = "<p>Like amber, pearl is not a gemstone mined from the earth, but it’s still regarded as one and is course prized as jewelry. For millennia pearls have been a symbol of purity, " +
                "refinement and wealth. Ancient cultures also considered pearls a vehicle for channeling wisdom and spiritual guidance.</p>" +
                "<p>When used in skin care, traditionally the Chinese, Mayan and Indian civilizations believed that ground pearls could help erase the signs of aging. " +
                "They were right, as pearls have shown the ability to smooth skin texture, renew skin cells and even battle acne.</p> ";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Pearl_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "Oily skin is a constant problem",
                "You need greater moisturization plus control of oily skin",
                "Brightening up a dull complexion is a concern",
                "Opening yourself to spiritual transformation is a goal",
                "Strengthening relationships means everything to you"
            };
            CharacteristicsImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_1126285136.jpg?resize=768%2C331&ssl=1";
            SymboslismText = "With their humble beginnings as ragged, rough grains of sand, transformed over time into objects of value and beauty, pearls symbolize a pure heart and simple honesty.";
            MoodText = "The moods most often associated with pearl are purity, spiritual transformation, charity, honesty, wisdom and integrity, protection and luck. Known for their calming effect, pearls can balance one’s karma and strengthen relationships. " +
                "Pearl is also said to symbolize the purity, generosity, integrity and loyalty of its wearer.";
            ColorAndCharacterText = "Pearls come in a wide range of colors and shades, including opalescent white, black, and every pastel shade in between, including pink, peach, silver, " +
                "cream, and gold, as well as dark and light purples, greenish blues and even browns.";
            ElementText = "Water, as it offers cleansing, healing, psychic and loving properties.";
        }
    }
}