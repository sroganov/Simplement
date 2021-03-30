using System;

namespace Simplement.Common.Core
{
    /// <summary>
    /// Default filter for objects with parents.
    /// </summary>
    public class FilterTreelike : FilterBase
    {
        public Guid? ParentId { get; set; }
        public bool? OnlyParents { get; set; }
    }
}
