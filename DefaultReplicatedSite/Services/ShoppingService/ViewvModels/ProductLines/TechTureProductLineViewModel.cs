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
            HeaderImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/shutterstock_1081362410.jpg?resize=2400%2C1800&ssl=1";
            ProductLineImage = "https://i0.wp.com/luxxium.net/wp-content/uploads/2019/04/TECH.png?w=760&amp;ssl=1";
        }
    }
}