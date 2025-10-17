using System;
using System.Threading;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryAsync<T, in TFilter>
        where T : IEntity
        where TFilter : FilterBase
    {
        Task<OperationResult<T>> GetAsync(Guid id, CancellationToken cancellationToken = default);
        Task<OperationResultPage<T>> GetAsync(PagerParams pager = null, TFilter filter = null, CancellationToken cancellationToken = default);
        Task<OperationResultList<T>> GetAllAsync(CancellationToken cancellationToken = default);
        Task<OperationResult<int>> GetRecordsCountAsync(TFilter filter, CancellationToken cancellationToken = default);

        Task<OperationResult<T>> AddAsync(T item, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> UpdateAsync(T item, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
        Task<OperationResult<T>> UndoDeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
