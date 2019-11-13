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
            HeaderImage = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/09/kristals_product_header-1.jpg?resize=2400%2C1800&ssl=1";
            ProductLineImage = "https://i1.wp.com/luxxium.net/wp-content/uploads/2019/04/unnamed.jpg?w=760&amp;ssl=1";
        }
    }
}