using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite
{
    public class UnitedStatesMarket : Market
    {
        public UnitedStatesMarket()
           : base()
        {
            CountryCode = "US";
            AddressSettings = new AddressFields
            {
                Address2 = true,
                State = false
            };
        }

        public IMarketConfiguration Configurations
        {
            get
            {
                return new UnitedStatesConfigurations();
            }
        }
    }
}