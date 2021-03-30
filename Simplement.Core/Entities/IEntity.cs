using System;

namespace Simplement.Core
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreationDate { get; set; }
        Guid? CreatedBy { get; set; }

        bool IsActive { get; set; }
    }
}
