using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class AventurineWebCategoryViewModel : WebCategoryViewModel
    {
        public AventurineWebCategoryViewModel()
        {
            WebCategoryID = 1004;
            Key = "acenturine";
            Name = "Aventurine";
            Title = "Kristals Aventurine";
            Items = new List<ProductModel>();
            ProductLineId = 1;
            ProductLineImageUrl = "/Content/Images/kristals_logo_black.jpg?fit=300%2C207&amp;ssl=1";
            HeaderImageUrl = "/Content/Images/Untitled-2.jpg";
            ShortDescription = "Thought to be one of the luckiest of all crystals, aventurine is known as the stone of opportunity.";
            ShortDescriptionListItems = new List<string> {
                "Helping boost collagen for plumper, fresher-looking skin",
                "Controlling skin inflammation and acne outbreaks",
                "Defending skin against the effects of sun exposure and contaminants"
            };
            ShortDescriptionImage = "/Content/Images/kri-aven-set_1024x1024.jpg";
            Description = "<p>Thought to be one of the luckiest of all crystals, aventurine is known as the “stone of opportunity.” " +
                "It’s believed to stimulate the flow of positive energy to open the doors for new ventures while helps sweep away old, bad habits and encourage new patterns of prosperity. " +
                "As part of that, aventurine brings optimism and confidence, amplifying innate leadership abilities.</p>" +
                "<p>Applied to skincare, aventurine appears to be helpful in controlling skin inflammation, which in turn can be useful when dealing with psoriasis, " +
                "acne and eczema. Aventurine also seems to offer benefits with connective tissue such as collagen, crucial for maintaining the skin’s youthful appearance.</p>";
            DescriptionImageUrl = "/Content/Images/Aventurine_B2.jpg";
            MatchList = new List<string> {
                "Sensitive skin is an issue and blemishes are priorities",
                "You have concerns about aging skin",
                "It’s time for a fresh start",
                "Taking charge is an important goal",
                "Opening yourself to positive energies is key"
            };
            CharacteristicsImageUrl = "/Content/Images/shutterstock_678404389.jpg";
            SymboslismText = "Amber exudes ancient energy. With it comes the accumulated wisdom of Strongly associated with luck, open possibilities and good fortune, aventurine was historically often symbolic of prosperity and wealth.";
            MoodText = "The moods most often associated with aventurine are revitalization, wisdom, confidence, knowledge and innocence, reinforcing decisiveness and opening the energies needed to take charge.";
            ColorAndCharacterText = "Most commonly green, though it also forms in blue, red to reddish-brown, dusty purple, orange or peach, yellow, and silver gray.";
            ElementText = "Earth, since aventurine is symbolic of the planet’s fertility and life.";
        }
    }
}