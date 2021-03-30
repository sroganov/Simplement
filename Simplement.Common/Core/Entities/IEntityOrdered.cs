namespace Simplement.Common.Core
{
    public interface IEntityOrdered : IEntity
    {
        int OrderNumber { get; set; }
    }
}
