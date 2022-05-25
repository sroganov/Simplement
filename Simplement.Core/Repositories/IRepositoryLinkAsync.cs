using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryLinkAsync<TModel, in TFilter>
        where TFilter : FilterLink
    {
        Task<OperationResultList<TModel>> GetAsync(Guid parentId);
        Task<OperationResultPage<TModel>> GetAsync(PagerParams pager = null, TFilter filter = null);

        Task<OperationResult<TModel>> GetAsync(Guid parentId, Guid childId);
    }
}
