﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace DefaultReplicatedSite.Models
{
    public class CheckoutAddress
    {
        public ContactInfo ContactInfo { get; set; }
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [DisplayName("Middle Name")]
        public string MiddleName { get; set; }
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("Address 2")]
        public string Address2 { get; set; }
        [DisplayName("Address 3")]
        public string Address3 { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("State")]
        public string State { get; set; }
        [DisplayName("Zip")]
        public string Zip { get; set; }
        public bool SaveInformation { get; set; }
        public bool OptIn { get; set; }
    }
}