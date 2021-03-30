namespace Simplement.Core
{
    public interface IEntityOrdered : IEntity
    {
        int OrderNumber { get; set; }
    }
}
