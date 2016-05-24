using BaystateHealth.Business.Services.WaitTimes.Rss.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaystateHealth.Business.Services.WaitTimes.Rss
{
    public class RssWaitTimeProvider : IWaitTimeProvider
    {
        private ConfigurationSection _configuration;

        public RssWaitTimeProvider()
        {
            _configuration = ConfigurationSection.Create();
        }

        public WaitTime GetWaitTime(object locationKey)
        {
            // Find the location element in config by key
            LocationElement element = _configuration.Locations.SingleOrDefault(l => l.Key == locationKey.ToString());
            if (element == null)
            {
                throw new Exception(string.Format("Location with key {0} not found.", locationKey));
            }

            return GetWaitTime(element);
        }

        public IEnumerable<WaitTime> GetWaitTimes()
        {
            foreach(LocationElement element in _configuration.Locations)
            {
                yield return GetWaitTime(element);
            }
        }

        private WaitTime GetWaitTime(LocationElement element)
        {
            // Use element.Url to get wait time properties for this element

            WaitTime waitTime = new WaitTime()
            {
                Key = element.Key
                // Duration = results.Duration
            };

            return waitTime;
        }
    }
}
