using System;

namespace Simplement.Core
{
    public interface IOperationLink<TModel, in TFilter>
        where TFilter : FilterLink
    {
        OperationResultList<TModel> Get(Guid parentId);
        OperationResultPage<TModel> Get(PagerParams pager = null, TFilter filter = null);

        OperationResult<TModel> Get(Guid parentId, Guid childId);
    }
}
