namespace TimeTracker.Shared.Entities;

public class TimeEntry : BaseEntity
{
    public required String Project { get; set; }
    public DateTime Start { get; set; } = DateTime.Now;
    public DateTime? End { get; set; }
}