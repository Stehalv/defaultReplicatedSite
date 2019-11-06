using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite
{
    public static partial class Settings
    {
        public static class API
        {
            // basic idea for demo purposes, however should move to version control for production client
            public static string Version { get { return "1.0.0"; } }
            public static int CompanyId { get { return 100; } }

            // Timeout for FormsAuthentication Cookie - Mins
            public static int SessionTimeout { get { return 120; } }

            // Token Data - move to web.config but for demo purposes will leave here
            public static string TokenUsername { get { return "LifocityBackofficeAPI"; } }
            public static string TokenPassword { get { return "L1f0cityAp1BO73@#"; } }
            public static int TokenRenewTimeout { get { return 15; } }
        }
        public static class Company
        {
            public static string Name = "Luxxium";
        }
        public static class Shop
        {
            public static bool AllowDiscountCodes = true;
            public static class AddressFields
            {
                public static bool State = true;
                public static bool Address2 = true;
                public static bool Address3 = true;
                public static bool Country = true;

            }
        }
    }
}