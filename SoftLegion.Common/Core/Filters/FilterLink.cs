using System;

namespace SoftLegion.Common.Core.Filters
{
    /// <summary>
    /// Наследование от FilterBase сохраняем для возможности работы с 
    /// </summary>
    public class FilterLink : FilterBase
    {
        /// <summary>
        /// ИД родительской записи, значение должно быть заполненым всегда.
        /// </summary>
        public Guid ParentId { get; set; }

        /// <summary>
        /// Ид дочерней записи, 
        /// при передачи пустого значения - получим все дочерние записи для родителской
        /// </summary>
        public Guid? ChildId { get; set; }

    }
}