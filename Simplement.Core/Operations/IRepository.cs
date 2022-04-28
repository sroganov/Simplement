using System;

namespace Simplement.Core
{
    public interface IRepository<T, in TFilter>
        where T : IEntity
        where TFilter : FilterBase
    {
        OperationResult<T> Get(Guid id);
        OperationResultPage<T> Get(PagerParams pager = null, TFilter filter = null);
        OperationResultList<T> GetAll();
        OperationResult<int> GetRecordsCount(TFilter filter);

        OperationResult<T> Add(T item);
        OperationResult<T> Update(T item);
        OperationResult<T> Delete(Guid id);
        OperationResult<T> UndoDelete(Guid id);
    }
}
