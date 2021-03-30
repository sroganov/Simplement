using System;

namespace Simplement.Common.Core
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreationDate { get; set; }
        DateTime? LastModifiedDate { get; set; }

        Guid? CreatedBy { get; set; }
        Guid? LastModifiedBy { get; set; }

        bool IsActive { get; set; }
    }
}
