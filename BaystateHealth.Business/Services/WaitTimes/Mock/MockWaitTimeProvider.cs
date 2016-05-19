using System;
using System.Collections.Generic;

namespace BaystateHealth.Business.Services.WaitTimes.Mock
{
    public class MockWaitTimeProvider : IWaitTimeProvider
    {
        private IDictionary<string, WaitTime> _waitTimes;

        public MockWaitTimeProvider()
        {
            _waitTimes = new Dictionary<string, WaitTime>()
            {
                { "1", new WaitTime() { Key = "1", Duration = new TimeSpan(3, 0, 0) } },
                { "2", new WaitTime() { Key = "2", Duration = new TimeSpan(2, 0, 0) } },
                { "3", new WaitTime() { Key = "3", Duration = new TimeSpan(1, 0, 0) } }
            };
        }

        public WaitTime GetWaitTime(object locationKey)
        {
            string key = locationKey.ToString();
            if (!_waitTimes.ContainsKey(key))
            {
                throw new Exception(string.Format("Location with key {0} not found.", key));
            }

            return _waitTimes[key];
        }

        public IEnumerable<WaitTime> GetWaitTimes()
        {
            foreach (WaitTime waitTime in _waitTimes.Values)
            {
                yield return waitTime;
            }
        }
    }
}
