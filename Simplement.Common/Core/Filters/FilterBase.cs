using System;

namespace Simplement.Common.Core
{
    public class FilterBase
    {
        public Guid? Id { get; set; }
        public bool? IsActive { get; set; }

        public string SearchText { get; set; }

        public SortDirection? OrderBy { get; set; }
    }
}
