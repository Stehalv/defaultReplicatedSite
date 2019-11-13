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
            ShortDescriptionImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/Spark9_800_2000x.jpg?resize=683%2C1024&ssl=1";
            Description = "SPARK PHOTON LED BEAUTY TECH";
        }
    }
}