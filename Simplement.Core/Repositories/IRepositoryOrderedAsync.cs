using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryOrderedAsync<T, in TFilter> : IRepositoryAsync<T, TFilter>
        where T : IEntityOrdered
        where TFilter : FilterBase
    {
        Task<OperationResult<T>> MoveUpAsync(Guid id, TFilter filter = null, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> MoveDownAsync(Guid id, TFilter filter = null, CancellationToken cancellationToken = default);
    }
}
