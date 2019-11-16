using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class SonicNeckMAssagerWebCategoryViewModel : WebCategoryViewModel
    {
        public SonicNeckMAssagerWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "sonicneckmassager";
            Name = "Sonic Neck Massager";
            ProductLineId = 2;
            ShortDescription = "The massage head is especially designed for shoulders, neck, and face";
            ShortDescriptionListItems = new List<string> {
                "The massage head heats to 45°C (113°F)",
                "Three sonic modes: Low speed (blue), medium speed (green), and high speed (red). Vibration begins when massage head make contact with skin, after mode is selected.",
                "Massage duration can be programmed with mode memory function"
            };
            ShortDescriptionImage = "/Content/Images/Front_red_New_720x.jpg";
            Description = "TORRE HOT/COLD SONIC NECK MASSAGER";
        }
    }
}