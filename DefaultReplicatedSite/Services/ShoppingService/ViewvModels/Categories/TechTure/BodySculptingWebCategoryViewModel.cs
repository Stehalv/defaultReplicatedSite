﻿using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class BodySculptingWebCategoryViewModel : WebCategoryViewModel
    {
        public BodySculptingWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "bodysculpting";
            Name = "Body Sculpting";
            ProductLineId = 2;
            ShortDescription = "<p>Truly lasting toned skin can only be crafted with the finest of tools.</p>" +
                "<p>The SculptTech EMS Body Sculpting Pro is a revolution in skincare technology, helping you to achieve relaxed muscles while lifting and firming skin with just a click of a button.</p>";
            ShortDescriptionListItems = new List<string> {
                "Body toning",
                "Lifts & Firms",
                "Easy at home use",
                "Painless"
            };
            ShortDescriptionImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/09/ST_03_360x.jpg?w=360&ssl=1";
            Description = "SPARK PHOTON LED BEAUTY TECH";
        }
    }
}