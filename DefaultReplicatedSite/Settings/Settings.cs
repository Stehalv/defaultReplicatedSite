using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DefaultReplicatedSite
{
    public static partial class Settings
    {
        public static class Company
        {
            public static string Name = "Luxxium";
        }
        public static class Shop
        {
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