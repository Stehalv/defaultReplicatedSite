using MakoLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class WebCategory : WebCategoryContract
    {
        public string Name { get; set; }
    }
}