using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MakoLibrary.Contracts;

namespace DefaultReplicatedSite.Models
{
    public class Customer
    {
        public Customer()
        {
            MailingAddress = new Address();
            ShippingAddress = new Address();
            BillingAddress = new Address();
            if(Settings.Shop.AllowSeparateAutoOrderAddress)
            {
                AutoOrderAddress = new Address();
            }
        }
        public long CustomerId { get; set; }
        [Required(ErrorMessageResourceName = "RequiredFirstName", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Checkout))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredLastName", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "LastName", ResourceType = typeof(Resources.Checkout))]
        public string LastName { get; set; }

        [Display(Name = "CompanyName", ResourceType = typeof(Resources.Checkout))]
        public string CompanyName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredEmailAddress", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "EmailAddress", ResourceType = typeof(Resources.Checkout))]
        public string EmailAddress { get; set; }

        [Required(ErrorMessageResourceName = "RequiredUserName", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "UserName", ResourceType = typeof(Resources.Checkout))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredUserPassword", ErrorMessageResourceType = typeof(Resources.Checkout)), RegularExpression(Settings.RegularExpressions.Password, ErrorMessageResourceName = "InvalidPassword", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "UserPassword", ResourceType = typeof(Resources.Checkout))]
        public string UserPassword { get; set; }

        [Display(Name = "WebAlias", ResourceType = typeof(Resources.Checkout))]
        public string WebAlias { get; set; }
        public bool EmailSubscribed { get; set; }

        [Required,
         DataType("TaxId"),
         RegularExpression(Settings.RegularExpressions.UnitedStatesTaxID,
             ErrorMessageResourceName = "InvalidTaxID",
             ErrorMessageResourceType = typeof(Resources.Checkout)),
         Display(Name = "TaxId", ResourceType = typeof(Resources.Checkout))
        , Remote("IsTaxIDAvailable", "App", ErrorMessageResourceName = "TaxIDUnavailable", ErrorMessageResourceType = typeof(Resources.Checkout))]
        public string TaxId { get; set; }

        [Required(ErrorMessageResourceName = "RequiredCellPhone", ErrorMessageResourceType = typeof(Resources.Checkout))]
        [Display(Name = "CellPhone", ResourceType = typeof(Resources.Checkout))]
        public string CellPhone { get; set; }
        [Display(Name = "HomePhone", ResourceType = typeof(Resources.Checkout))]
        public string HomePhone { get; set; }
        public GenderTypes Gender { get; set; }
        public long EnrollerId { get; set; }
        public int CustomerType { get; set; }
        public int CustomerStatusType { get; set; }
        public long EnrollerBusinessCenterId { get; set; }

        public Address MailingAddress { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public Address AutoOrderAddress { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public CRMCustomerCreateContract ToCustomerCReate()
        {
            var c = new CRMCustomerCreateContract();
            c.BillingAddress = BillingAddress.ToCRMAddress();
            c.CompanyName = CompanyName;
            c.CountryCode = GlobalUtilities.Globalization.GetSelectedCountryCode();
            c.CurrencyCode = GlobalUtilities.Globalization.GetSelectedMaret().CurrencyCode;
            c.CustomerStatusType = (int)CustomerStatuses.Commissionable;
            c.CustomerSubStatusType = (int)CustomerSubStatuses.Active;
            c.CustomerSubType = (int)CustomerSubTypes.None;
            //Todo: Add logic for multiple customertypes
            c.CustomerType = (int)CustomerTypes.Influencer;
            c.EmailAddress = EmailAddress;
            c.EmailSubscribed = EmailSubscribed;
            c.EmailSubscribedDate = DateTime.Now;
            c.EmailSubscribedIp = HttpContext.Current.Request.UserHostAddress;
            c.EntryDate = DateTime.Now;
            c.FirstName = FirstName;
            c.FullName = FullName;
            c.GenderType = (int)Gender;
            c.LastName = LastName;
            c.MailingAddress = MailingAddress.ToCRMAddress();
            c.OtherAddress1 = AutoOrderAddress.ToCRMAddress();
            c.PhoneNumbers = new CRMExtendedPhones
            {
                CellPhone = CellPhone,
                HomePhone = HomePhone
            };
            c.ShippingAddress = ShippingAddress.ToCRMAddress();
            c.SignUpDate = DateTime.Now;
            c.UserCanLogIn = true;
            c.UserName = UserName;
            c.UserPassword = UserPassword;
            c.WebAlias = WebAlias;
            return c;
        }
    }
}
