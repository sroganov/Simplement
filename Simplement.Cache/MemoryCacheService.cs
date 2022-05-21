using System;
using System.Linq;
using System.Runtime.Caching;
using System.Threading.Tasks;
using Simplement.Core;

namespace Simplement.Cache
{
    public class MemoryCacheService : ICacheService
    {
        // NOTE: Adding key prefix as duplicate keys protection, in case of direct usage of MemoryCache.
        private const string KeyPrefix = "memory_cache_service";
        private static string GetCacheKey(string key) => $"{KeyPrefix}_{key}";

        protected ObjectCache Storage => MemoryCache.Default;

        public OperationResult<T> Get<T>(string key)
        {
            return Get<T>(key, null);
        }

        public virtual OperationResult<T> Get<T>(string key, Func<T> creator, int expiration = 1440)
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

        public virtual OperationResult<T> Add<T>(string key, T value, int expiration = 1440)
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

        public virtual OperationResult Update<T>(string key, T value, int expiration = 1440)
        {
            if (value == null)
                return OperationResult.Fail();

            var fullKey = GetCacheKey(key);
            if (!Storage.Contains(fullKey))
                return OperationResult.Fail();

            Storage.Set(fullKey, value, DateTime.Now.AddMinutes(expiration));
            return OperationResult.Success();
        }

        public virtual OperationResult Delete(string key)
        {
            var fullKey = GetCacheKey(key);
            if (!Storage.Contains(fullKey))
                return OperationResult.Fail();

            Storage.Remove(fullKey);
            return OperationResult.Success();
        }

        public virtual OperationResult Clear()
        {
            var items = Storage.Where(i => i.Key.StartsWith(KeyPrefix)).ToList();
            foreach (var item in items)
                Storage.Remove(item.Key);

            return OperationResult.Success();
        }

        protected static T GetValue<T>(Func<T> creator)
        {
            if (creator == null)
                return default;

            return creator() ?? default;
        }

        protected static async Task<T> GetValueAsync<T>(Func<Task<T>> creator)
        {
            if (creator == null)
                return default;

            return await creator() ?? default;
        }

        public async Task<OperationResult<T>> GetAsync<T>(string key)
        {
            return Get<T>(key);
        }

        public async Task<OperationResult<T>> GetAsync<T>(string key, Func<Task<T>> creator, int expiration = 1440)
        {
            var fullKey = GetCacheKey(key);
            if (Storage.Contains(fullKey))
                return new OperationResult<T>
                {
                    Result = OperationStatus.Success,
                    Value = (T) Storage.Get(fullKey)
                };

            var value = await GetValueAsync(creator);
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

        public async Task<OperationResult<T>> AddAsync<T>(string key, T value, int expiration = 1440)
        {
            return Add<T>(key, value, expiration);
        }

        public async Task<OperationResult> UpdateAsync<T>(string key, T value, int expiration = 1440)
        {
            return Update<T>(key, value, expiration);
        }

        public async Task<OperationResult> DeleteAsync(string key)
        {
            return Delete(key);
        }

        public async Task<OperationResult> ClearAsync()
        {
            return Clear();
        }
    }
}
