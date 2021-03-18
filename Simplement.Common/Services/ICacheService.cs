using System;
using SoftLegion.Common.Core.OperationResults;

namespace SoftLegion.Common.Services
{
    public interface ICacheService : IService
    {
        /// <summary>
        /// Gets existing value or null if no value exists.
        /// </summary>
        /// <returns></returns>
        OperationResult<T> Get<T>(string key);

        /// <summary>
        /// Gets existing value or adds new one using creator function if no value exists.
        /// Cache expiration timeout in minutes.
        /// </summary>
        OperationResult<T> Get<T>(string key, Func<T> creator, int expiration = 1440);

        /// <summary>
        /// Updates existing value.
        /// Cache expiration timeout in minutes.
        /// Returns true if success, otherwise false.
        /// </summary>
        OperationResult Update<T>(string key, T value, int expiration = 1440);

        /// <summary>
        /// Removes existing value.
        /// Returns true if success, otherwise false.
        /// </summary>
        OperationResult Delete(string key);

        /// <summary>
        /// Removes ALL values in cache storage.
        /// Returns true if success, otherwise false.
        /// </summary>
        /// <returns></returns>
        OperationResult Clear();
    }
}