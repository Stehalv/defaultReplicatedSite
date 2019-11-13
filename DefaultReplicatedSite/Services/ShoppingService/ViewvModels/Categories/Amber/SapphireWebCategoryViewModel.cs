using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class SapphireWebCategoryViewModel : WebCategoryViewModel
    {
        public SapphireWebCategoryViewModel()
        {
            WebCategoryID = 1001;
            Key = "sapphire";
            Name = "Sapphire";
            Title = "Kristals Sapphire";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/Kristals_sapphire_2048x2048.jpg?resize=712%2C400&ssl=1";
            ShortDescription = "Different cultures saw sapphire as signifying power balanced by kindness, focus and wise judgement.";
            ShortDescriptionListItems = new List<string> {
                "Calming inflamed skin and avoiding outbreaks of irritation",
                "Promoting anti-aging by energizing skin",
                "Working with complementary compounds to erase fine lines and wrinkles"
            };
            ShortDescriptionImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/sapphire_grande.jpg?w=760&ssl=1";
            Description = "<p>The striking blue color of this precious stone inspired the ancients to associate it with the heavens, so as time went by sapphire was believed to protect, " +
                "bring good fortune and open the doors to spiritual insights. Traditions in different cultures also saw sapphire as signifying power balanced by kindness, focus and wise judgement. " +
                "These days, crystal enthusiasts believe that sapphire opens the mind and sharpens the intuition so that we can make ideas reality.</p>" +
                "<p>When applied to skincare, sapphire helps soothe inflamed skin, cleanse it and minimize damage caused by the rays of the sun and environmental contaminants.</p>";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Sapphire_B2.jpg?w=590&ssl=1";
            MatchList = new List<string> {
                "You want to stabilize sensitive skin",
                "Smoothing out lines is a major goal",
                "Lifting sagging skin is an area of focus",
                "Unlocking spiritual energy is important",
                "You’re an intuitive person Creativity is a core quality of yours"
            };
            CharacteristicsImageUrl = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_316715627.jpg?w=760&ssl=1";
            SymboslismText = "Sapphires represent wealth, success and strength. Because of this symbolism, many believe that sapphire is a stone that helps achieve dreams, often by sharpening our natural intuition and focus to make the right decisions so ideas become reality.";
            MoodText = "The moods most often associated with sapphire are serenity, contentment, tranquility. As such, the stone is believed to dispel unwanted thoughts, provide spiritual strength and bring peace of mind.";
            ColorAndCharacterText = "Blue, translucent sapphire ranges in hue from pale to deep azure or dark royal blue, to indigo, with the most highly desired color being the velvety cornflower blue, also called Kashmir or Bleu De Roi.";
            ElementText = "Water, because sapphire offers cleansing, healing, psychic and loving properties.";
        }
    }
}