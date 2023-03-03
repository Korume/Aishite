using System.Runtime.Caching;

namespace Aishite.SettignsManagement
{
    public class MemoryStorage : IDataStorage
    {
        private readonly MemoryCache _memoryCache;

        public MemoryStorage()
        {
            _memoryCache = MemoryCache.Default;
        }

        public T? GetValue<T>(string key)
            where T : class
        {
            return _memoryCache.Contains(key) ? (T)_memoryCache[key] : null;
        }

        public void SetValue<T>(string key, T value)
            where T : class
        {
            _memoryCache[key] = value;
        }
    }
}
