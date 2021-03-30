using System;

namespace Simplement.Core
{
    public interface IOperationHistory<T, THistory, in TFilter> : IOperation<T, TFilter>
        where T : IEntity
        where THistory : IEntityHistory<T>
        where TFilter : FilterHistoryBase
    {
        OperationResult<THistory> GetHistory(Guid entityId, DateTime recordDate);
        OperationResultPage<T> GetHistory(PagerParams pager = null, TFilter filter = null);
    }
}
