using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultReplicatedSite
{
    public interface IMarketConfiguration
    {
        IOrderConfiguration Order { get; }
        IOrderConfiguration AutoOrder { get; }
        IOrderConfiguration Enrollment { get; }
        IOrderConfiguration EnrollmentAutoOrder { get; }
    }
}
