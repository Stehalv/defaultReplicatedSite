using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class AmethystWebCategoryViewModel : WebCategoryViewModel
    {
        public AmethystWebCategoryViewModel()
        {
            WebCategoryID = 1002;
            Key = "amethyst";
            Name = "Amethyst";
            Title = "Kristals Amethyst";
            Items = new List<ProductModel>();
            ProductLineId = 1;
            ProductLineImageUrl = "/Content/Images/kristals_logo_black.jpg";
            HeaderImageUrl = "/Content/Images/Amethys_b2_big.jpg";
            ShortDescription = "Amethyst was reputed to help soothe the emotions while carrying the fires of passion, creativity and spirituality within.";
            ShortDescriptionListItems = new List<string> {
                "Providing much-needed oxygen to the skin.",
                "Exfoliating skin gently to slough off dead skin cells and reveal new skin",
                "Deeply moisturizing skin"
            };
            ShortDescriptionImage = "/Content/Images/Amethyst_Set_products_page.jpg";
            Description = "Known throughout the ages as a “soul stone,” amethyst was reputed to help soothe the emotions while carrying the fires of passion, creativity and spirituality within. Balancing out the fires are other qualities associated with amethyst, like temperance and sobriety." +
                " These days, experts in the use of crystals recommend amethyst because it’s believe that the stone’s inherent high frequency purifies negative energy and creates a protective shield of light around the body that allows you to remain centered. " +
                "When applied to skincare, amethyst can help cleanse the skin of toxins, excess oils and daily debris such as dead skin cells. The stone also works to promote the flow of oxygen to the skin.";
            DescriptionImageUrl = "/Content/Images/Amethyst_b2.jpg";
            MatchList = new List<string> {
                "Restoring freshness to your skin is a goal",
                "Your skin needs even deeper moisturization that what it’s getting",
                "Proper exfoliation is a concern",
                "Greater spiritual balance is key",
                "You wish to dispel negative energy"
            };
            CharacteristicsImageUrl = "/Content/Images/shutterstock_735691957.jpg";
            SymboslismText = "Traditionally worn since ancient times to guard against intoxication and to instill a sober mind, amethyst is believed to protect one from poisons and toxins.";
            MoodText = "The moods most often associated with amethyst are tranquility, clarity, soothing and activation of spiritual awareness. Amethyst opens intuition and offers strong healing and cleansing powers. It helps the mind become more focused, enhancing memory and improving motivation.";
            ColorAndCharacterText = "Typically translucent light pinkish violet, lilac or mauve to a deep, see-through purple, Amethyst may exhibit one or both secondary hues of red and blue.";
            ElementText = "Air and water, as air relates to metal clarity, freedom and awareness, while water offers healing properties.";
        }
    }
}