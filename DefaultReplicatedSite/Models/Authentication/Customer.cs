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
        public Customer()
        {
            MailingAddress = new Address();
            ShippingAddress = new Address();
            BillingAddress = new Address();
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                OtherAddress1 = new Address();
            }
            PhoneNumbers = new CRMExtendedPhones();
        }
        [Required(ErrorMessageResourceName = "RequiredFirstName", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string FirstName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredLastName", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string LastName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredEmailAddress", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string EmailAddress { get; set; }
        [Required(ErrorMessageResourceName = "RequiredUserName", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string UserName { get; set; }
        [Required(ErrorMessageResourceName = "RequiredUserPassword", ErrorMessageResourceType = typeof(App_GlobalResources.Checkout))]
        public new string UserPassword { get; set; }
        public new bool EmailSubscribed { get; set; }
    }
}