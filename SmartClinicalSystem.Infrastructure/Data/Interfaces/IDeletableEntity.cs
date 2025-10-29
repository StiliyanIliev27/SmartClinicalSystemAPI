namespace SmartClinicalSystem.Infrastructure.Data.Interfaces
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
        DateTime? DeletedOn { get; set; }

    }
}
