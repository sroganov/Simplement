using System;
using System.Threading.Tasks;

namespace Simplement.Core
{
    public interface IOperationOrderedAsync<T, in TFilter> : IOperationAsync<T, TFilter>
        where T : IEntityOrdered
        where TFilter : FilterBase
    {
        Task<OperationResult<T>> MoveUp(Guid id, TFilter filter = null);
        Task<OperationResult<T>> MoveDown(Guid id, TFilter filter = null);
    }
}
