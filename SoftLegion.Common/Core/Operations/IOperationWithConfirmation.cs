using System;
using SoftLegion.Common.Core.Entities;
using SoftLegion.Common.Core.Filters;
using SoftLegion.Common.Core.OperationResults;

namespace SoftLegion.Common.Core.Operations
{
    public interface IOperationWithConfirmation<T, in TFilter> : IOperation<T, TFilter>
        where T : IEntity
        where TFilter : FilterBase
    {
        /// <summary>
        /// Проверка на подтверждение, добавление
        /// </summary>
        OperationResult<T> AddConfirmation(T model);

        /// <summary>
        /// Проверка на подтверждение, редактирование
        /// </summary>
        OperationResult<T> UpdateConfirmation(T model);

        /// <summary>
        /// Проверка на подтверждение, Удаление
        /// </summary>
        OperationResult<T> DeleteConfirmation(Guid id);

        /// <summary>
        /// Проверка на подтверждение, восстановление
        /// </summary>
        OperationResult<T> UndoDeleteConfirmation(Guid id);
    }
}