namespace SoftLegion.Common.Core.Entities
{
    public interface IEntityOrdered : IEntity
    {
        int OrderNumber { get; set; }
    }
}