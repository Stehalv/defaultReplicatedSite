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
            Items = new List<ProductModel>();
            ProductLineId = 1;
            ProductLineImageUrl = "/Content/Images/kristals_logo_black.jpg";
            HeaderImageUrl = "/Content/Images/AMBER_1_2048x2048-1.jpg";
            ShortDescription = "It’s believed that amber can purify homes and bring good luck.";
            ShortDescriptionListItems = new List<string> {
                "Helping the skin regain its youthful glow.",
                "Minimizing the appearance of pores.",
                "Reducing fine lines.",
                "Evening skin tone."
            };
            ShortDescriptionImage = "/Content/Images/Amber_set_grande_products_page.jpg";
            Description = "Technically, amber really isn’t a gemstone at all. Unlike sapphires and rubies, which are mined from the earth, amber comes from tree resin, formed over thousands of years. Traditionally, amber was used for a variety of illnesses, including colds. It was included as part of powders, tinctures and ointments. Beyond medicine, it’s been believed that amber can purify homes and bring good luck.";
            DescriptionImageUrl = "/Content/Images/Amber_B2.jpg";
            MatchList = new List<string> {
                "It’s important to attract positive energy and drive away negative.",
                "You’d like to target fine lines and brighten your complexion.",
                "Uneven skin tone is a problem.",
                "Balance is crucial to you."
            };
            CharacteristicsImageUrl = "/Content/Images/shutterstock_500657872.jpg";
            SymboslismText = "Amber exudes ancient energy. With it comes the accumulated wisdom of the earth and its natural kingdom. Often little insects and other living things were trapped in the amber while it started as a tree resin, which gives the amber stone quite powerful magical properties.";
            MoodText = "Warm, healing, wise, protective, cheerful. Amber balances emotions, attracts good luck, eliminates fears, relieves headache and clears the mind, and dissolve negatives energy while helping develop patience and wisdom.";
            ColorAndCharacterText = "Amber is golden yellow, pale yellow, deep cherry red to dark brown, with a rich translucency. Careful heat treatment can induce a spangled effect and also darken the surface.";
            ElementText = "Amber is golden yellow, pale yellow, deep cherry red to dark brown, with a rich translucency. Careful heat treatment can induce a spangled effect and also darken the surface.";
        }
    }
}