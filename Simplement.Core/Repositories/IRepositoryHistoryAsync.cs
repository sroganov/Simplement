using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryHistoryAsync<T, THistory, in TFilter> : IRepositoryAsync<T, TFilter>
        where T : IEntity
        where THistory : IEntityHistory<T>
        where TFilter : FilterHistoryBase
    {
        Task<OperationResult<THistory>> GetHistoryAsync(Guid entityId, DateTime recordDate, CancellationToken cancellationToken = default);
        Task<OperationResultPage<T>> GetHistoryAsync(PagerParams pager = null, TFilter filter = null, CancellationToken cancellationToken = default);
    }
}
