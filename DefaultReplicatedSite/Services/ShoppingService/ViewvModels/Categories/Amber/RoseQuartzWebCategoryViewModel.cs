using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class RoseQuartzWebCategoryViewModel : WebCategoryViewModel
    {
        public RoseQuartzWebCategoryViewModel()
        {
            WebCategoryID = 1009;
            Key = "rosequartz";
            Name = "Rose Quartz";
            Title = "Kristals Rose Quartz";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/Rose_Quartz_B2_big.jpg?resize=1185%2C667&ssl=1";
            ShortDescription = "Prized as a ‘love stone,’ believed to strengthen various types of love, including romantic love, love of family and even self-love in the form of self-esteem.";
            ShortDescriptionListItems = new List<string> {
                "Softening and smoothing skin",
                "Helping reduce wrinkles",
                "Evening out skin tone",
                "Giving the skin a natural glow"
            };
            ShortDescriptionImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/rose_quartz-set_grande.jpg?w=760&ssl=1";
            Description = "<p>These days, spas developed rose quartz treatments because they’ve discovered how this gemstone can help diminish the appearance of lines and wrinkles, " +
                "even out skin tone and give skin a healthy, natural glow. The trendspotters seem to have caught on to what the ancients knew thousands of years ago: " +
                "rose quartz masks have been found in Egyptian tombs because they were one of the beauty treatments favored by that civilization.</p>" +
                "<p>Beyond its effect on appearance, rose quartz has been prized as a “love stone,” believed to strengthen various types of love, including romantic love, " +
                "love of family and even self-love in the form of self-esteem. It’s also been believed that rose quartz alleviates stress, prevents nightmares and promotes pleasant dreams.</p>";
            DescriptionImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/Rose_Quartz_B1.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "You’d like to upgrade your skin cleansing gently but effectively",
                "Acne and blemishes are a problem for you",
                "Driving away negative energy is a priority",
                "You need better emotional balance"
            };
            CharacteristicsImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/03/shutterstock_140711065.jpg?w=760&ssl=1";
            SymboslismText = "Given its strong association with love, rose quartz is said to balance emotions and promote the positive energies of compassion, healing, nourishment and comfort.";
            MoodText = "The moods most often associated with rose quartz are love, compassion, contentment and happiness. It counteracts negative emotions, promotes empathy and sensitivity and increases willpower and energy.";
            ColorAndCharacterText = "Rose quartz’s shades vary from pale to strong pink, with many believing that a stone with a more intense pink shade has greater power.";
            ElementText = "Water, especially related to emotions, such as tears of joy, tears of sadness and tears of laughter, because tears are a water-based expression of human emotions.";
        }
    }
}