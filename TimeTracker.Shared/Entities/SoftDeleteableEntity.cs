namespace TimeTracker.Shared.Entities;

public class SoftDeleteableEntity : BaseEntity
{
    public bool isDeleted { get; set; } = false;
    public DateTime? DateDeleted { get; set; }
}