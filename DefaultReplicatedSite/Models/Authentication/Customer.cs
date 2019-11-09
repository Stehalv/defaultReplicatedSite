using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class Customer : CRMCustomerCreateContract
    {
        [Required]
        public new string FirstName { get; set; }
        [Required]
        public new string LastName { get; set; }
        [Required]
        public new string EmailAddress { get; set; }
        [Required]
        public new string UserName { get; set; }
        [Required]
        public new string UserPassword { get; set; }
        public new bool EmailSubscribed { get; set; }
    }
}