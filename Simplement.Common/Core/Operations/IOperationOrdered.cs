using System;

namespace Simplement.Common.Core
{
    public interface IOperationOrdered<T, in TFilter> : IOperation<T, TFilter>
        where T : IEntityOrdered
        where TFilter : FilterBase
    {
        OperationResult<T> MoveUp(Guid id, TFilter filter = null);
        OperationResult<T> MoveDown(Guid id, TFilter filter = null);

        OperationResult Sort();
    }
}
