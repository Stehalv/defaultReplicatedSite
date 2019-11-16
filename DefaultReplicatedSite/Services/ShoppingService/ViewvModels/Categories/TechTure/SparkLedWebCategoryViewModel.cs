using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class SparkLedWebCategoryViewModel : WebCategoryViewModel
    {
        public SparkLedWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "sparkled";
            Name = "Techture Spark Led";
            ProductLineId = 2;
            ShortDescription = "Rejuventaion technology for non-invasive facial treatments that will diminish the appearance of fine lines and wrinkles.";
            ShortDescriptionListItems = new List<string> {
                "Diminishes appearance of fine lines and large pores",
                "Age-reversing",
                "Shrinks appearance of blemishes",
                "Painless",
                "Easy to use"
            };
            ShortDescriptionImage = "/Content/Images/Spark9_800_2000x.jpg";
            Description = "SPARK PHOTON LED BEAUTY TECH";
        }
    }
}