using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class Address
    {
        public Address()
        {
            CountryCode = GlobalUtilities.Globalization.GetSelectedCountryCode();
        }
        [Required(ErrorMessageResourceName = "RequiredAddress1", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "Address1", ResourceType = typeof(Resources.Checkout))]
        public string Address1 { get; set; }

        [Display(Name = "Address2", ResourceType = typeof(Resources.Checkout))]
        public string Address2 { get; set; }

        [Display(Name = "Address3", ResourceType = typeof(Resources.Checkout))]
        public string Address3 { get; set; }

        [Required(ErrorMessageResourceName = "RequiredCity", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "City", ResourceType = typeof(Resources.Checkout))]
        public string City { get; set; }

        [Required(ErrorMessageResourceName = "RequiredState", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "StateRegion", ResourceType = typeof(Resources.Checkout))]
        public string RegionProvState { get; set; }

        [Required(ErrorMessageResourceName = "RequiredZip", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "Zip", ResourceType = typeof(Resources.Checkout))]
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        public CRMExtendedAddress ToCRMAddress()
        {
            return new CRMExtendedAddress
            {
                Address1 = Address1,
                Address2 = Address2,
                Address3 = Address3,
                City = City,
                RegionProvState = RegionProvState,
                PostalCode = PostalCode,
                CountryCode = CountryCode
            };
        }
    }
}