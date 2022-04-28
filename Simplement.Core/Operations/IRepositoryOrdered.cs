using System;

namespace Simplement.Core
{
    public interface IRepositoryOrdered<T, in TFilter> : IRepository<T, TFilter>
        where T : IEntityOrdered
        where TFilter : FilterBase
    {
        OperationResult<T> MoveUp(Guid id, TFilter filter = null);
        OperationResult<T> MoveDown(Guid id, TFilter filter = null);
    }
}
