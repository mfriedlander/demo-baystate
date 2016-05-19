using System.Collections.Generic;

namespace BaystateHealth.Business.Services.WaitTimes
{
    public interface IWaitTimeProvider
    {
        IEnumerable<WaitTime> GetWaitTimes();

        WaitTime GetWaitTime(object locationKey);
    }
}
