using DefaultReplicatedSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

namespace DefaultReplicatedSite.ViewModels
{
    public class ProductLineViewModel
    {
        public string Key { get; set; }
        public int ID { get; set; }
        public int WebCategoryId { get; set; }
        public string Description { get; set; }
        public string HeaderImage { get; set; }
        public string ProductLineImage { get; set; }
        public string Name { get; set; }
        public List<WebCategoryViewModel> Categories { get; set; }
        public string Title { get; set; }
        public string HeaderHtml { get; set; }
        public string FooterHtml { get; set; }
    } 
}