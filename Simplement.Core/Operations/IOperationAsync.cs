using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IOperationAsync<T, in TFilter>
        where T : IEntity
        where TFilter : FilterBase
    {
        Task<OperationResult<T>> Get(Guid id);
        Task<OperationResultPage<T>> Get(PagerParams pager = null, TFilter filter = null);
        Task<OperationResultList<T>> GetAll();
        Task<OperationResult<int>> GetRecordsCount(TFilter filter);

        Task<OperationResult<T>> Add(T item);
        Task<OperationResult<T>> Update(T item);
        Task<OperationResult<T>> Delete(Guid id);
        Task<OperationResult<T>> UndoDelete(Guid id);
    }
}
