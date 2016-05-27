using System;

namespace BaystateHealth.Business.Services.Cache
{
    public interface ICache
    {
        bool Contains(object key);

        T Select<T>(object key);

        void Add<T>(object key, T value, TimeSpan duration);
    }
}
