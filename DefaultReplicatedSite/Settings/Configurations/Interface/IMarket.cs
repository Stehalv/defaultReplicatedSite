using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite
{
    public interface IMarket
    {
        string CountryCode { get; set; }
        string CultureCode { get; set; }
        string CurrencyCode { get; set; }
        bool IsDefault { get; set; }
    }
}
