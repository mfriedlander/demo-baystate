using System;
using System.Collections.Generic;

namespace BaystateHealth.Business.Services.Cache.Mock
{
    public class MockCache : ICache
    {
        private IDictionary<string, object> _cache;

        public MockCache()
        {
            _cache = new Dictionary<string, object>();
        }

        public void Add<T>(object key, T value, TimeSpan duration)
        {
            if (_cache.ContainsKey(key.ToString()))
            {
                _cache[key.ToString()] = value;
            }
            else
            {
                _cache.Add(key.ToString(), value);
            }
        }

        public bool Contains(object key)
        {
            return _cache.ContainsKey(key.ToString());
        }

        public T Select<T>(object key)
        {
            return (T)_cache[key.ToString()];
        }
    }
}
