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
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/ROCK_CRYSTAL_1_2048x2048.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "Known for amplifying whichever energy or intent it receives, broadcasting that energy outward.";
            ShortDescriptionListItems = new List<string> {
                "Cleansing and protecting the skin",
                "Moisturizing",
                "Promoting overall skin health"
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/rock_crystal.jpg?w=760&ssl=1";
            Description = "Long prized by a variety of ancient civilizations, rock crystal is considered to be one of the top healing stones. " +
                "Ancient Greeks believed that their gods drank their ambrosia on Mount Olympus using goblets made of rock crystal, and it later made its way into folklore and pop culture through crystals balls used for divination. " +
                "This stone is known for amplifying whichever energy or intent it receives, broadcasting that energy outward. Here’s a look at some of its key characteristics:";
            DescriptionImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/Rock_Crystal_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "You’re looking for a strong foundation for basic skin care",
                "You seek greater clarity and purpose",
                "Calm and focus are important to you"
            };
            CharacteristicsImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_612498125.jpg?w=760&ssl=1";
            SymboslismText = "Rock crystal is a symbol of chastity, purity of thoughts, innocence, modesty and fidelity. Ancients believed these stones to be alive, taking a breath once every hundred years or so, " +
                "and many cultures thought them to be incarnations of the Divine.";
            MoodText = "The moods most often associated with rock crystal are strength, clarity, focus and calm. Its hypnotic quality is conducive to sleep, " +
                "helping one to understand the messages and lessons conveyed during the dream state.";
            ColorAndCharacterText = "Rock crystals are transparent and have a glassy appearance, with color that varies from milky white to colorless.";
            ElementText = "Air, as it relates to metal clarity, freedom and awareness.";
        }
    }
}