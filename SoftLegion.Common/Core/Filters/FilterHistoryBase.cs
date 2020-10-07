using System;

namespace SoftLegion.Common.Core.Filters
{
    /// <summary>
    /// Default filter.
    /// </summary>
    public class FilterHistoryBase : FilterBase
    {
        /// <summary>
        /// Пометка искать ли в данных истории
        /// </summary>
        public bool SearchInHistory { get; set; }

        /// <summary>
        /// Дата действия записи
        /// </summary>
        public DateTime? ActualDateFrom { get; set; }
    }
}