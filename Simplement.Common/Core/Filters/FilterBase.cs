using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using SoftLegion.Common.Core.Enums;

namespace SoftLegion.Common.Core.Filters
{
    /// <summary>
    /// Default filter.
    /// </summary>
    public class FilterBase
    {
        public List<Guid> Ids { get; set; }

        public Guid? Id { get; set; }
        public bool? IsActive { get; set; }

        public string SearchText { get; set; }

        /// <summary>
        /// Сортировка по возрастанию или убыванию
        /// NULL - отсутсвует сортировка
        /// True - Сортировка по возрастанию
        /// False - Сортировка по убыванию
        /// </summary>
        public OrderingType? OrderBy { get; set; }

        //Подготовленная поисковая строка, на клиент её не возвращаем
        [JsonIgnore]
        public string SearchTextSimplified =>
            string.IsNullOrEmpty(SearchText) ? string.Empty : SearchText.ToLower().Trim();
    }
}