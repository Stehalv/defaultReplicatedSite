using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class SuperSonicScrubberWebCategoryViewModel : WebCategoryViewModel
    {
        public SuperSonicScrubberWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "supersonicscrubber";
            Name = "Super Sonic Scrubber";
            ProductLineId = 2;
            ShortDescription = "This gel primer acts as a microcurrent activator to prime skin for treatment and allow your device to glide easily and comfortably over your skin. " +
                "This gentle formula contains Organic Aloe Vera Gel, Witch Hazel Extract and Vitamin B5 to soothe and protect skin. The Micro Current Activator is an important first step before any EMS treatment to ensure your device delivers maximum microcurrent conductivity. " +
                "Easy to apply, easy to wash off. Your skin will thank you!";
            ShortDescriptionListItems = new List<string>();
            ShortDescriptionImage = "/Content/Images/UCG_Front_2000x.jpg";
            Description = "SUPERSONIC SKIN SCRUBBER";
        }
    }
}