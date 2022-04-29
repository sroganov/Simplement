using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryLinkAsync<TModel, in TFilter>
        where TFilter : FilterLink
    {
        Task<OperationResultList<TModel>> Get(Guid parentId);
        Task<OperationResultPage<TModel>> Get(PagerParams pager = null, TFilter filter = null);

        Task<OperationResult<TModel>> Get(Guid parentId, Guid childId);
    }
}
