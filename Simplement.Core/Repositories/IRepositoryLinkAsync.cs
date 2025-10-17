using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryLinkAsync<TModel, in TFilter>
        where TFilter : FilterLink
    {
        Task<OperationResultList<TModel>> GetAsync(Guid parentId, CancellationToken cancellationToken = default);
        Task<OperationResultPage<TModel>> GetAsync(PagerParams pager = null, TFilter filter = null, CancellationToken cancellationToken = default);

        Task<OperationResult<TModel>> GetAsync(Guid parentId, Guid childId, CancellationToken cancellationToken = default);
    }
}
