using System;
using SoftLegion.Common.Core.Entities;
using SoftLegion.Common.Core.Filters;
using SoftLegion.Common.Core.OperationResults;

namespace SoftLegion.Common.Core.Operations
{
    /// <summary>
    /// Работа с сортируемыми записями
    /// </summary>
    /// <typeparam name="T">Модель должна содержать, OrderNumber</typeparam>
    /// <typeparam name="TFilter">Фильтр</typeparam>
    public interface IOperationOrdered<T, in TFilter> : IOperation<T, TFilter>
        where T : IEntityOrdered
        where TFilter : FilterBase
    {
        OperationResult<T> MoveUp(Guid id, TFilter filter = null);
        OperationResult<T> MoveDown(Guid id, TFilter filter = null);
        OperationResult SortByName();
    }
}