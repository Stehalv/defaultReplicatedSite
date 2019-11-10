using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite
{
    public class Market : IMarket
    {
        public string CountryCode { get; set; }
        public string CultureCode { get; set; }
        public string CurrencyCode { get; set; }
        public bool IsDefault { get; set; }
        public AddressFields AddressSettings { get; set; }
        public IMarketConfiguration Configurations { get; }
    }
    public class AddressFields
    {
        public bool State { get; set; }
        public bool Address2 { get; set; }
        public bool Address3 { get; set; }
        public bool SelectCountry { get; set; }

    }
}