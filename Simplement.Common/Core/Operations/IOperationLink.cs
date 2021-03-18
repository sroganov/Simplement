using System;
using SoftLegion.Common.Core.Filters;
using SoftLegion.Common.Core.OperationResults;
using SoftLegion.Common.Core.Paging;

namespace SoftLegion.Common.Core.Operations
{
    /// <summary>
    /// Интерфейс для работы с связанными данными
    /// </summary>
    /// <typeparam name="TModel">Дочерняя модель</typeparam>
    /// <typeparam name="TFilter">Фильтр типа связанных записей</typeparam>
    public interface IOperationLink<TModel, in TFilter>
        where TFilter : FilterLink
    {
        /// <summary>
        /// Возвращаем список дочерних моделей для родителя
        /// </summary>
        /// <param name="parentId">Id- родителя</param>
        /// <returns>Список дочерних моделей без пейджинга</returns>
        OperationResultList<TModel> Get(Guid parentId);

        /// <summary>
        /// Возвращаем список дочерних моделей для родителя с пейджингом
        /// </summary>
        /// <param name="pager">пейджинг</param>
        /// <param name="filter">фильтр</param>
        /// <returns>Список дочерних моделей с пейджингом</returns>
        OperationResultPage<TModel> Get(PagerParams pager = null, TFilter filter = null);

        /// <summary>
        /// Возвращаем одну конкретную запись связи
        /// </summary>
        /// <param name="parentId">Master</param>
        /// <param name="childId">Details</param>
        /// <returns>Одна запись</returns>
        OperationResult<TModel> Get(Guid parentId, Guid childId);
    }

}