using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryHistoryAsync<T, THistory, in TFilter> : IRepositoryAsync<T, TFilter>
        where T : IEntity
        where THistory : IEntityHistory<T>
        where TFilter : FilterHistoryBase
    {
        Task<OperationResult<THistory>> GetHistoryAsync(Guid entityId, DateTime recordDate);
        Task<OperationResultPage<T>> GetHistoryAsync(PagerParams pager = null, TFilter filter = null);
    }
}
