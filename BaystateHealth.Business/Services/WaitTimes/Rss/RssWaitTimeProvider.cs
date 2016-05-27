using BaystateHealth.Business.Services.Cache;
using BaystateHealth.Business.Services.WaitTimes.Rss.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BaystateHealth.Business.Services.WaitTimes.Rss
{
    public class RssWaitTimeProvider : IWaitTimeProvider
    {
        private readonly string CACHE_PREFIX;
        private ConfigurationSection _configuration;
        private ICache _cache;

        public RssWaitTimeProvider(ICache cache)
        {
            CACHE_PREFIX = "RssWaitTimeProvider:Facility:";
            _configuration = ConfigurationSection.Create();
            _cache = cache;
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
            // Calculate cache key
            string cacheKey = CACHE_PREFIX + element.Key;

            // If it's not in cache, add it
            if (!_cache.Contains(cacheKey))
            {
                // TODO: implementation of wait time retreival
                WaitTime waitTime = new WaitTime()
                {
                    Key = element.Key,
                    Duration = new TimeSpan(0, 4, 0)
                };

                // Add to cache; NOTE: duration can come from config
                _cache.Add<WaitTime>(cacheKey, waitTime, new TimeSpan(0, 10, 0));
            }

            return _cache.Select<WaitTime>(cacheKey);
        }
    }
}
