using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DefaultReplicatedSite.Models
{
    public class CheckoutAddress : Address
    {
        public ContactInfo ContactInfo { get; set; }
        public bool SaveInformation { get; set; }
        public bool OptIn { get; set; }
    }
}