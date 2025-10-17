using System;
using System.Threading;
using System.Threading.Tasks;
using Simplement.Core;

namespace Simplement.Cache;

/// <summary>
/// Definition of caching service.
/// </summary>
public interface ICacheServiceAsync : IService
{
    /// <summary>
    /// Async Gets existing value or null if no value exists.
    /// </summary>
    Task<OperationResult<T>> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Async Gets existing value or adds new one using creator function if no value exists.
    /// Cache expiration timeout in minutes.
    /// </summary>
    Task<OperationResult<T>> GetAsync<T>(string key, Func<Task<T>> creator, int expiration = 1440, CancellationToken cancellationToken = default);

    /// <summary>
    /// Async Adds new value into cache if no value exists for given key, otherwise fails.
    /// Cache expiration timeout in minutes.
    /// </summary>
    Task<OperationResult<T>> AddAsync<T>(string key, T value, int expiration = 1440, CancellationToken cancellationToken = default);

    /// <summary>
    /// Async Updates existing value.
    /// Cache expiration timeout in minutes.
    /// </summary>
    Task<OperationResult> UpdateAsync<T>(string key, T value, int expiration = 1440, CancellationToken cancellationToken = default);

    /// <summary>
    /// Async Removes existing value.
    /// </summary>
    Task<OperationResult> DeleteAsync(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Async Removes ALL values in cache storage.
    /// </summary>
    Task<OperationResult> ClearAsync(CancellationToken cancellationToken = default);
}
