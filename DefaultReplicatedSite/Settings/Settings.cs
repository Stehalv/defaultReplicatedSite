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
            public static string APITokenName = Company.Name + "RepsiteToken";
        }
        public static class Company
        {
            public static string Name = "Luxxium";
            public static string CookieName = "Luxxium";
            public static string ReplicatedHost = "";
        }
        public static class Site
        {
            public static string DefaultWebalias = "5";
            public static bool AllowOrphans = true;
            public static int IdentityRefreshInterval = 31;
        }
        public static class Shop
        {
            public static bool AllowDiscountCodes = false;
            public static bool AllowSeparateAutoOrderAddress = true;
        }
        public static class Globalization
        {
            public static string CookieKey = "Luxxium";
            public static string CountryCookieName = CookieKey + "SelectedCountry";
            public static string LanguageCookieName = CookieKey + "SelectedLanguage";
            public static class Markets
            {
                public static List<Market> AvailableMarkets
                {
                    get
                    {
                        return new List<Market>
                    {
                        new UnitedStatesMarket(),
                    };
                    }
                }
            }
            public static class Language
            {

            }
        }
    }
}