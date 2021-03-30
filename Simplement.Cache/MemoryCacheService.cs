using System;
using System.Linq;
using System.Runtime.Caching;
using Simplement.Core;

namespace Simplement.Cache
{
    public class MemoryCacheService : ICacheService
    {
        // NOTE: Adding key prefix as duplicate keys protection, in case of direct usage of MemoryCache.
        private const string KeyPrefix = "memory_cache_service";
        private static string GetCacheKey(string key) => $"{KeyPrefix}_{key}";

        private static ObjectCache Storage => MemoryCache.Default;

        public OperationResult<T> Get<T>(string key)
        {
            return Get<T>(key, null);
        }

        public OperationResult<T> Get<T>(string key, Func<T> creator, int expiration = 1440)
        {
            var fullKey = GetCacheKey(key);
            if (Storage.Contains(fullKey))
                return new OperationResult<T>
                {
                    Result = OperationStatus.Success,
                    Value = (T) Storage.Get(fullKey)
                };

            var value = GetValue(creator);
            if (value == null)
                return OperationResult<T>.Fail();

            if (!Storage.Add(fullKey, value, DateTime.Now.AddMinutes(expiration)))
                return OperationResult<T>.Fail();

            return new OperationResult<T>
            {
                Result = OperationStatus.Success,
                Value = value
            };
        }

        public OperationResult<T> Add<T>(string key, T value, int expiration = 1440)
        {
            var fullKey = GetCacheKey(key);
            if (Storage.Contains(fullKey))
                return OperationResult<T>.Fail();

            if (!Storage.Add(fullKey, value, DateTime.Now.AddMinutes(expiration)))
                return OperationResult<T>.Fail();

            return new OperationResult<T>
            {
                Result = OperationStatus.Success,
                Value = value
            };
        }

        public OperationResult Update<T>(string key, T value, int expiration = 1440)
        {
            if (value == null)
                return OperationResult.Fail();

            var fullKey = GetCacheKey(key);
            if (!Storage.Contains(fullKey))
                return OperationResult.Fail();

            Storage.Set(fullKey, value, DateTime.Now.AddMinutes(expiration));
            return OperationResult.Success();
        }

        public OperationResult Delete(string key)
        {
            var fullKey = GetCacheKey(key);
            if (!Storage.Contains(fullKey))
                return OperationResult.Fail();

            Storage.Remove(fullKey);
            return OperationResult.Success();
        }

        public OperationResult Clear()
        {
            var items = Storage.Where(i => i.Key.StartsWith(KeyPrefix)).ToList();
            foreach (var item in items)
                Storage.Remove(item.Key);

            return OperationResult.Success();
        }

        private static T GetValue<T>(Func<T> creator)
        {
            if (creator == null)
                return default;

            return creator() ?? default;
        }
    }
}
