namespace DefaultReplicatedSite
{
    public static class ApiQuery
    {
        public static class SearchMethod
        {
            public const string IsEqual             = "eq";
            public const string StartsWith          = "sw";
            public const string EndsWith            = "ew";
            public const string Contains            = "cn";
            public const string GreaterThan         = "gt";
            public const string LessThan            = "lt";
            public const string GreaterThanEqual    = "gteq";
            public const string LessThanEqual       = "lteq";
        }

        public static class SearchSort
        {
            public const string Ascending   = "asc";
            public const string Descending  = "desc";
        }
    }
}