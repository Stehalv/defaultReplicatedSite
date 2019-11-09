using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite
{
    public interface IOrderConfiguration
    {
        int PriceTypeID { get; set; }
        string CountryCode { get; set; }
    }
}
