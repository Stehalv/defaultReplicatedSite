using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class CreditCard
    {
        [Required(ErrorMessageResourceName = "RequiredNameOnCard", ErrorMessageResourceType = typeof(Resources.Checkout))]
        public string NameOnCard { get; set; }

        [Required(ErrorMessageResourceName = "RequiredCardNumber", ErrorMessageResourceType = typeof(Resources.Checkout))]
        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }
        [Required(ErrorMessageResourceName = "RequiredCVV", ErrorMessageResourceType = typeof(Resources.Checkout))]
        public string CVV { get; set; }

        public string Token { get; set; }
        public string Display { get; set; }
    }
}