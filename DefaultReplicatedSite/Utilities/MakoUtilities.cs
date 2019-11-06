using MakoLibrary.Contracts;
using System;
using System.Linq;

namespace DefaultReplicatedSite
{
    public static partial class GlobalUtilities
    {
        public class Mako
        {
            public PeriodContract GetCurrentPeriod(int periodTypeId)
            {
                var response = Teqnavi.ServiceContext().GetPeriods();

                if (!response.Success || response.Data == null) return null;

                // get current period using start and end(+24hours) dates
                var currentPeriod = response.Data
                    .Where(w => w.PeriodTypeId == periodTypeId)
                    .Where(w => w.StartDate <= DateTime.Now && w.EndDate.AddDays(1) >= DateTime.Now)
                    .FirstOrDefault();

                // in case no period for this period, get max of current periods available
                if (currentPeriod == null)
                {
                    currentPeriod = response.Data.Where(w => w.PeriodTypeId == periodTypeId && w.PeriodId == response.Data.Max(m => m.PeriodId)).FirstOrDefault();
                }

                return currentPeriod ?? new PeriodContract();
            }

            internal object GetCurrentPeriod(object periodTyes)
            {
                throw new NotImplementedException();
            }
        }
    }
}