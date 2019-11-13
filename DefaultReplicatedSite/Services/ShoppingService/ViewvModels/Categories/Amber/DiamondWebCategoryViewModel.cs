using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class DiamondWebCategoryViewModel : WebCategoryViewModel
    {
        public DiamondWebCategoryViewModel()
        {
            WebCategoryID = 1005;
            Key = "diamond";
            Name = "Diamond";
            Title = "Kristals Diamond";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/10/Diamond_banner_2048x2048.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "Admired for its strength and therefore called ‘the stone of invincibility,’ believed to bring courage and fortitude to those who wore it.";
            ShortDescriptionListItems = new List<string> {
                "Preventing collagen degradation",
                "Exfoliating skin to eliminate the dead skin cells on upper layers to reveal fresher skin underneath",
                "Nourishing the skin with antioxidants and oxygen"
            };
            ShortDescriptionImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/KRI-DIA-SET_grande.jpg?w=600&ssl=1";
            Description = "<p>Even those who are unfamiliar with the power of crystals and gemstones know that diamonds are a symbol of beauty, prized in all sorts of adornments. " +
                "This esteem for the “king of the gems” has been shared by many cultures over thousands of years.Besides being prized for its sparking beauty, " +
                "diamond was admired for its strength and therefore called “the stone of invincibility,” believed to bring courage and fortitude to those who wore it.</p>" +
                "<p>When used for skincare, it’s been observed that diamond has strong exfoliating properties, moisturizes well and protects collagen, the key connective tissue that helps skin maintain a fresh, " +
                "young-looking appearance.</p>";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Diamond_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "Your skin is undernourished",
                "Saggy skin is a concern",
                "Problems due to sun damage have surfaced",
                "Daily demands require resiliency and fortitude",
                "Inspiration and intuition are important"
            };
            CharacteristicsImageUrl = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_325468397.jpg?w=760&ssl=1";
            SymboslismText = "It is a spiritual stone, a symbol of perfection and illumination, activating the Crown and Etheric Chakras. It enhances inner vision and stimulates creativity, imagination, and ingenuity, opening the mind to the “new” and “possible.”";
            MoodText = "The moods most often associated with diamond are strength, indomitability, resilience and endurance.";
            ColorAndCharacterText = "While diamonds form in many colors, the clear, colorless diamond is a stone of light, diffusing all the colors of the spectrum.";
            ElementText = "Fire, as it represents the beginning of everything in that it brought all other elements to life. Brings the sun’s power and the fire element energy to one’s personal space.";
        }
    }
}