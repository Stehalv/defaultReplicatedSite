using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class AmberWebCategoryViewModel : WebCategoryViewModel
    {
        public AmberWebCategoryViewModel()
        {
            WebCategoryID = 1000;
            Key = "amber";
            Name = "Amber";
            Title = "Kristals Amber";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/09/AMBER_1_2048x2048-1.jpg?resize=1200%2C675&ssl=1";
            ShortDescription = "It’s believed that amber can purify homes and bring good luck.";
            ShortDescriptionListItems = new List<string> {
                "Helping the skin regain its youthful glow.",
                "Minimizing the appearance of pores.",
                "Reducing fine lines.",
                "Evening skin tone."
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/09/Amber_set_grande_products_page.jpg?w=600&ssl=1";
            Description = "Technically, amber really isn’t a gemstone at all. Unlike sapphires and rubies, which are mined from the earth, amber comes from tree resin, formed over thousands of years. Traditionally, amber was used for a variety of illnesses, including colds. It was included as part of powders, tinctures and ointments. Beyond medicine, it’s been believed that amber can purify homes and bring good luck.";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/09/Amber_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "It’s important to attract positive energy and drive away negative.",
                "You’d like to target fine lines and brighten your complexion.",
                "Uneven skin tone is a problem.",
                "Balance is crucial to you."
            };
            CharacteristicsImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_500657872.jpg?w=760&ssl=1";
            SymboslismText = "Amber exudes ancient energy. With it comes the accumulated wisdom of the earth and its natural kingdom. Often little insects and other living things were trapped in the amber while it started as a tree resin, which gives the amber stone quite powerful magical properties.";
            MoodText = "Warm, healing, wise, protective, cheerful. Amber balances emotions, attracts good luck, eliminates fears, relieves headache and clears the mind, and dissolve negatives energy while helping develop patience and wisdom.";
            ColorAndCharacterText = "Amber is golden yellow, pale yellow, deep cherry red to dark brown, with a rich translucency. Careful heat treatment can induce a spangled effect and also darken the surface.";
            ElementText = "Amber is golden yellow, pale yellow, deep cherry red to dark brown, with a rich translucency. Careful heat treatment can induce a spangled effect and also darken the surface.";
        }
    }
}