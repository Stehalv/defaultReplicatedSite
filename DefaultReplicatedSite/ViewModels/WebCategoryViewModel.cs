using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.ViewModels
{
    public class WebCategoryViewModel : WebCategory
    {
        public List<Item> Items { get; set; }
        public List<WebCategory> ChildCategories { get; set; }
    }
}