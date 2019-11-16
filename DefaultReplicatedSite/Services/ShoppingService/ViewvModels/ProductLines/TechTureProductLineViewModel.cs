using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class TechTureProductLineViewModel : ProductLineViewModel
    {
        public TechTureProductLineViewModel()
        {
            ID = 2;
            Key = "techture";
            Name = "TechTure Beauty Products";
            Description = "TECHTURE ADVANCED <br>SKINCARE TECHNOLOGY";
            Title = "Beauty Meets Technology";
            HeaderImage = "/Content/Images/shutterstock_1081362410.jpg";
            ProductLineImage = "/Content/Images/TECH.png";
        }
    }
}