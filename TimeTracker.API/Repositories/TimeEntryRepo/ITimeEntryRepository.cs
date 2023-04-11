namespace TimeTracker.API.Repositories.TimeEntryRepo;

public interface ITimeEntryRepository
{
    Task<TimeEntry?> GetTimeEntryById(int id);
    Task<List<TimeEntry>> GetAllTimeEntries();
    Task<List<TimeEntry>> CreateNewTimeEntry(TimeEntry timeEntry);
    List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry);
    List<TimeEntry>? DeleteTimeEntry(int id);
}