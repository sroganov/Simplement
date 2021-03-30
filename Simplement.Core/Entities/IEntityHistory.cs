using System;

namespace Simplement.Core
{
    public interface IEntityHistory<T>
        where T : IEntity
    {
        Guid EntityId { get; set; }

        Guid? PrevRecordId { get; set; }
        Guid? NextRecordId { get; set; }

        DateTime RecordDate { get; set; }

        T Record { get; set; }
    }
}
