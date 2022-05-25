using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IRepositoryAsync<T, in TFilter>
        where T : IEntity
        where TFilter : FilterBase
    {
        Task<OperationResult<T>> GetAsync(Guid id);
        Task<OperationResultPage<T>> GetAsync(PagerParams pager = null, TFilter filter = null);
        Task<OperationResultList<T>> GetAllAsync();
        Task<OperationResult<int>> GetRecordsCountAsync(TFilter filter);

        Task<OperationResult<T>> AddAsync(T item);
        Task<OperationResult<T>> UpdateAsync(T item);
        Task<OperationResult<T>> DeleteAsync(Guid id);
        Task<OperationResult<T>> UndoDeleteAsync(Guid id);
    }
}
