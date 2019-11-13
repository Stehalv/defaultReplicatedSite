using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class GoldWebCategoryViewModel : WebCategoryViewModel
    {
        public GoldWebCategoryViewModel()
        {
            WebCategoryID = 1006;
            Key = "gold";
            Name = "Gold";
            Title = "Kristals Gold";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/gold_2048x2048-1.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "Associated with a number of benefits beyond skincare, with traditional healers believing it promoted vitality, clarity and unity.";
            ShortDescriptionListItems = new List<string> {
                "Nourishing skin with antioxidants",
                "Increasing skin’s elasticity and flexibility",
                "Helping reduce wrinkles Lending resplendence to the skin"
            };
            ShortDescriptionImage = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/04/kri-gold-set_grande.jpg?w=760&ssl=1";
            Description = "<p>Long a symbol of beauty and power, gold has been used for beauty treatments even before Cleopatra reportedly used it to enhance her skin more than 2,000 years ago. " +
                "Ancient Romans favored gold as a way to treat skin lesions, and even in more recent times, gold was part of a treatment for arthritis. " +
                "These days, gold has been shown to help in wound healing, skin exfoliation and by providing important antioxidants.</p>" +
                "<p>Gold has been associated with a number of benefits beyond skincare, with traditional healers believing it promoted vitality, clarity and unity.</p>";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Gold_B2_big.jpg?resize=768%2C432&ssl=1";
            MatchList = new List<string> {
                "Targeting wrinkles is an important concern",
                "Your skin needs more nourishment from vitamins",
                "Uneven skin tone presents challenges",
                "You strive for perfection in all that you do",
                "Increasing your vitality is crucial"
            };
            CharacteristicsImageUrl = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_167974427.jpg?w=760&ssl=1";
            SymboslismText = "Gold is symbolic of flexibility on one’s spiritual path. It represents perfection in all matters, on any level, and symbolizes humankind’s quest to perfect, illuminate and refine. " +
                "Because of its resistance to heat and acid, gold is also symbol of immutability, eternity and perfection.";
            MoodText = "The moods most often associated with gold are vigor, vitality, radiance and transparency.";
            ColorAndCharacterText = "Gold is quite commonly known as being a soft, shiny, yellow, heavy and malleable metal.";
            ElementText = "Obviously metal, which is one of the Five Taoist elements.";
        }
    }
}