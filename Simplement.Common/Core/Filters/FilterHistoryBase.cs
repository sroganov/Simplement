using System;

namespace Simplement.Common.Core
{
    public class FilterHistoryBase : FilterBase
    {
        public DateTime? RecordDateFrom { get; set; }
        public DateTime? RecordDateTo { get; set; }
    }
}
