using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite.Models
{
    public class ContactInfo
    {
        [DisplayName("Please Provide your email Address")]
        public string Email { get; set; }
    }
}