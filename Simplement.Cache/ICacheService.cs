using System;
using Simplement.Core;

namespace Simplement.Cache
{
    /// <summary>
    /// Definition of caching service.
    /// </summary>
    public interface ICacheService : IService
    {
        /// <summary>
        /// Gets existing value or null if no value exists.
        /// </summary>
        OperationResult<T> Get<T>(string key);

        /// <summary>
        /// Gets existing value or adds new one using creator function if no value exists.
        /// Cache expiration timeout in minutes.
        /// </summary>
        OperationResult<T> Get<T>(string key, Func<T> creator, int expiration = 1440);

        /// <summary>
        /// Adds new value into cache if no value exists for given key, otherwise fails.
        /// Cache expiration timeout in minutes.
        /// </summary>
        OperationResult<T> Add<T>(string key, T value, int expiration = 1440);

        /// <summary>
        /// Updates existing value.
        /// Cache expiration timeout in minutes.
        /// </summary>
        OperationResult Update<T>(string key, T value, int expiration = 1440);

        /// <summary>
        /// Removes existing value.
        /// </summary>
        OperationResult Delete(string key);

        /// <summary>
        /// Removes ALL values in cache storage.
        /// </summary>
        OperationResult Clear();
    }
}
