using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class RockCrystalWebCategoryViewModel : WebCategoryViewModel
    {
        public RockCrystalWebCategoryViewModel()
        {
            WebCategoryID = 1008;
            Key = "rockcrystal";
            Name = "Rock Crystal";
            Title = "Kristals Rock Crystal";
            Items = new List<ProductModel>();
            ProductLineId = 1;
            ProductLineImageUrl = "/Content/Images/kristals_logo_black.jpg";
            HeaderImageUrl = "/Content/Images/ROCK_CRYSTAL_1_2048x2048.jpg";
            ShortDescription = "Known for amplifying whichever energy or intent it receives, broadcasting that energy outward.";
            ShortDescriptionListItems = new List<string> {
                "Cleansing and protecting the skin",
                "Moisturizing",
                "Promoting overall skin health"
            };
            ShortDescriptionImage = "/Content/Images/rock_crystal.jpg";
            Description = "Long prized by a variety of ancient civilizations, rock crystal is considered to be one of the top healing stones. " +
                "Ancient Greeks believed that their gods drank their ambrosia on Mount Olympus using goblets made of rock crystal, and it later made its way into folklore and pop culture through crystals balls used for divination. " +
                "This stone is known for amplifying whichever energy or intent it receives, broadcasting that energy outward. Here’s a look at some of its key characteristics:";
            DescriptionImageUrl = "/Content/Images/Rock_Crystal_B2.jpg";
            MatchList = new List<string> {
                "You’re looking for a strong foundation for basic skin care",
                "You seek greater clarity and purpose",
                "Calm and focus are important to you"
            };
            CharacteristicsImageUrl = "/Content/Images/shutterstock_612498125.jpg";
            SymboslismText = "Rock crystal is a symbol of chastity, purity of thoughts, innocence, modesty and fidelity. Ancients believed these stones to be alive, taking a breath once every hundred years or so, " +
                "and many cultures thought them to be incarnations of the Divine.";
            MoodText = "The moods most often associated with rock crystal are strength, clarity, focus and calm. Its hypnotic quality is conducive to sleep, " +
                "helping one to understand the messages and lessons conveyed during the dream state.";
            ColorAndCharacterText = "Rock crystals are transparent and have a glassy appearance, with color that varies from milky white to colorless.";
            ElementText = "Air, as it relates to metal clarity, freedom and awareness.";
        }
    }
}