using System;
using System.Threading.Tasks;

namespace Caching
{
    public interface ICacheManager : IDisposable
    {
        Task<string> GetAsync(string cacheKey);
        Task<T> GetAsync<T>(string key, Func<Task<T>> acquire, int? cacheTime = null);
        T Get<T>(string key, Func<T> acquire, int? cacheTime = null);
        Task SetAsync(string key, object data, int cacheTime);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        void Remove(string key);
        void RemoveByPrefix(string prefix);
        void Clear();
    }
}
