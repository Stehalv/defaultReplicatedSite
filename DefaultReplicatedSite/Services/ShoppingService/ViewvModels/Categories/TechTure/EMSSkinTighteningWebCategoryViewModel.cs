using DefaultReplicatedSite.Models;
using DefaultReplicatedSite.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Services
{
    public class EMSSkinTighteningWebCategoryViewModel : WebCategoryViewModel
    {
        public EMSSkinTighteningWebCategoryViewModel()
        {
            ItemCode = "";
            Key = "emsskintightening";
            Name = "EMS Skin Tightening";
            ProductLineId = 2;
            ShortDescription = "<p>Skin feels immediately better, tighter, more toned. A quick look in the mirror reveals a newer level of radiance as lines begin to fade.</p>" +
                "<p>The E-Pulse can help repair the skin’s elastic fiber and collagen layer tissue, thereby relaxing and reducing wrinkles.</p>" +
                "<p>Skin will feel: </p>";
            ShortDescriptionListItems = new List<string> {
                "Smoother",
                "Tighter ",
                "More toned"
            };
            ShortDescriptionImage = "https://i2.wp.com/luxxium.net/wp-content/uploads/2019/04/EMS2_800_720x.jpg?resize=683%2C1024&ssl=1";
            Description = "E-PULSE EMS PRO TECH SKIN TIGHTENING TREATMENT";
        }
    }
}