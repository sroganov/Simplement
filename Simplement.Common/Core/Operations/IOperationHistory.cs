using System;
using SoftLegion.Common.Core.Entities;
using SoftLegion.Common.Core.Filters;
using SoftLegion.Common.Core.OperationResults;
using SoftLegion.Common.Core.Paging;

namespace SoftLegion.Common.Core.Operations
{
    /// <summary>
    /// Операции с историчностью
    /// </summary>
    /// <typeparam name="T">Основная модель</typeparam>
    /// <typeparam name="THistory">Историческая модель</typeparam>
    /// <typeparam name="TFilter">Фильтр</typeparam>
    public interface IOperationHistory<T, THistory, in TFilter> : IOperation<T, TFilter>
        where T : IEntity
        where THistory : IHistoryEntity
        where TFilter : FilterHistoryBase
    {
        /// <summary>
        /// Получить данные из истории на дату
        /// </summary>
        /// <param name="entityId">Id родительской актуальной записи</param>
        /// <param name="actualDateFrom">Дата действия записи</param>
        /// <returns>Модель родительской записи</returns>
        OperationResult<THistory> GetHistory(Guid entityId, DateTime actualDateFrom);

        /// <summary>
        /// Получить данные из истории на дату
        /// </summary>
        /// <param name="pager">Пейджер</param>
        /// <param name="filter">Фильтр</param>
        /// <returns>Список исторических записей приведённых к основному виду</returns>
        OperationResultPage<T> GetHistory(PagerParams pager = null, TFilter filter = null);
    }
}