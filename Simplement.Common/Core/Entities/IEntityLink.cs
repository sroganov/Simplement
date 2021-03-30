using System;

namespace Simplement.Common.Core
{
    public interface IEntityLink<TFirst, TSecond>
        where TFirst : IEntity
        where TSecond : IEntity
    {
        Guid FirstId { get; set; }
        Guid SecondId { get; set; }

        TFirst First { get; set; }
        TSecond Second { get; set; }
    }
}
