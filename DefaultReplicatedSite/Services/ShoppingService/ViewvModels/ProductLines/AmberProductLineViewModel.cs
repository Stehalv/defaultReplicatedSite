using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class AmberProductLineViewModel : ProductLineViewModel
    {
        public AmberProductLineViewModel()
        {
            ID = 1;
            Key = "kristals";
            Name = "Kristals";
            Description = "KRISTALS<br> GEMSTONE SKINCARE";
            Title = "Balanced Energy";
            HeaderImage = "/Content/Images/kristals_product_header-1.jpg";
            ProductLineImage = "/Content/Images/KristalCosmetics.jpg";
        }
    }
}