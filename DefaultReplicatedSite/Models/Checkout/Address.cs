using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class Address: CRMExtendedAddress
    {
        [Required(ErrorMessageResourceName = "RequiredAddress1", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string Address1 { get; set; }
        [Required(ErrorMessageResourceName = "RequiredAddress2", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string Address2 { get; set; }
        public new string Address3 { get; set; }
        [Required(ErrorMessageResourceName = "RequiredCity", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string City { get; set; }
        [Required(ErrorMessageResourceName = "RequiredState", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string RegionProvState { get; set; }
        [Required(ErrorMessageResourceName = "RequiredZip", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string PostalCode { get; set; }
        public new string CountryCode { get; set; }
    }
}