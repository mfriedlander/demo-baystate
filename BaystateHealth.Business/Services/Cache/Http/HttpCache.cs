using System;
using System.Web;
using System.Web.Caching;

namespace BaystateHealth.Business.Services.Cache.Http
{
    public class HttpCache : ICache
    {
        private System.Web.Caching.Cache _cache
        {
            get
            {
                return HttpContext.Current.Cache;
            }
        }

        public void Add<T>(object key, T value, TimeSpan duration)
        {
            _cache.Add(
                key.ToString(), 
                value, 
                null,
                DateTime.Now.AddMinutes(10), 
                System.Web.Caching.Cache.NoSlidingExpiration, 
                CacheItemPriority.Default,
                null);
        }

        public bool Contains(object key)
        {
            return _cache[key.ToString()] != null;
        }

        public T Select<T>(object key)
        {
            return (T)_cache[key.ToString()];
        }
    }
}
