using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class CreditCard
    {
        public string NameOnCard { get; set; }

        public string CardNumber { get; set; }

        public int ExpirationMonth { get; set; }

        public int ExpirationYear { get; set; }
        public string CVV { get; set; }

        public string Token { get; set; }
        public string Display { get; set; }
    }
}