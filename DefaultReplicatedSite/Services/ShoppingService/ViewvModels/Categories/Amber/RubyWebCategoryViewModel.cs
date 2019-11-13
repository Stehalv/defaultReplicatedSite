using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class RubyWebCategoryViewModel : WebCategoryViewModel
    {
        public RubyWebCategoryViewModel()
        {
            WebCategoryID = 1010;
            Key = "ruby";
            Name = "Ruby";
            Title = "Kristals Ruby";
            Items = new List<Item>();
            ProductLineId = 1;
            ProductLineImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/Ruby_B2_big.jpg?resize=819%2C461&ssl=1";
            ShortDescription = "Associated with wisdom, wealth and health, rubies were also used as part of medical treatments in ancient times for fever, infections and more.";
            ShortDescriptionListItems = new List<string> {
                "Strengthening and nourishing the skin",
                "Creating a youthful glow",
                "Promoting overall skin health"
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/ruby-set_1_grande.jpg?w=760&ssl=1";
            Description = "A number of ancient civilizations admired this fiery red gemstone. In fact, ruby’s name in Sanskrit translates to “the king of precious stones.” " +
                "Beyond being associated with wisdom, wealth and health, rubies were also used as part of medical treatments in ancient times for fever, infections, blood circulation and more.  " +
                "Here’s a look at some of its key characteristics:";
            DescriptionImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/ruby_2048x2048-1.jpg?resize=768%2C374&ssl=1";
            MatchList = new List<string> {
                "You want to smooth out wrinkles",
                "You want to add moisturizing power to your skincare routine",
                "Boosting self-esteem is important to you",
                "Better concentration and motivation are keys for you"
            };
            CharacteristicsImageUrl = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/10/shutterstock_197153348_ruby.jpg?resize=768%2C638&ssl=1";
            SymboslismText = "Ruby has always been a talisman of passion, protection and prosperity. It symbolizes the sun, and its glowing hue suggests an inextinguishable flame within the stone. Rubies are reputed to bring peace, " +
                "drive away nightmares, restrain lust and help resolve disputes.";
            MoodText = "The moods most often associated with ruby are clearness of thought, increased concentration, motivation, power, self-confidence and determination. Ruby has also always been associated with love, " +
                "especially faithful, passionate commitment and closeness.";
            ColorAndCharacterText = "True rubies display a shade of red that falls within a specific range of colors, including pure rich reds and bluish/purplish reds in a variety of shades with red always dominant, " +
                "though rubies from some regions may be pinkish or orange-red";
            ElementText = "Fire, as it represents the beginning of everything in that it brought all other elements to life. Ruby brings the sun’s power and the fire element energy to one’s personal space.";
        }
    }
}