using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class SuperSonicSkinScrubberWebCategoryViewModel : WebCategoryViewModel
    {
        public SuperSonicSkinScrubberWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "supersonicskinscrubber";
            Name = "Super Sonic Skin Scrubber";
            ProductLineId = 2;
            ShortDescription = "If you’re plagued by clogged pores and blackheads, dull or flaky patches, or congested skin, you’ll love the way this at-home version of the popular spa service will treat your skin.";
            ShortDescriptionListItems = new List<string> {
                "Deep cleansing action with a sonophoresis treatment",
                "Deep clean your complexion without any redness or irritation",
                "Preps skin for deeper moisturizing allowing all your products to work better and infuse nutrients directly into your skin. "
            };
            ShortDescriptionImage = "/Content/Images/TECHTURE_Supersonic_Skin_SCRUBBER_Device_with_Purifying_Facial_Mist_720x.jpg";
            Description = "SUPERSONIC SKIN SCRUBBER";
        }
    }
}