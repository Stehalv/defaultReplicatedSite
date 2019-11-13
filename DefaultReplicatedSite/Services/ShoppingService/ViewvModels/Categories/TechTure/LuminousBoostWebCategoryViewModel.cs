﻿using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class LuminousBoostWebCategoryViewModel : WebCategoryViewModel
    {
        public LuminousBoostWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "luminousboost";
            Name = "24K Gold Sonic Luminous Boost";
            ProductLineId = 2;
            ShortDescription = "Get Ready to Boost Your Skincare Regimen: Experience radiant, youthful skin with the 24K Gold Sonic Luminous Boost, a 2-in-1 treatment created to accelerate results with the simple click of a button. Scroll down to learn more!";
            ShortDescriptionListItems = new List<string>();
            ShortDescriptionImage = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/10/LMB_001_2000x.jpg?resize=683%2C1024&ssl=1";
            Description = "24K GOLD SONIC LUMINOUS BOOST";
        }
    }
}