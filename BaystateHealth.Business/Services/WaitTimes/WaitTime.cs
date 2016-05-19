using System;

namespace BaystateHealth.Business.Services.WaitTimes
{
    public class WaitTime
    {
        public object Key { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
