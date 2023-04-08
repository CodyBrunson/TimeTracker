using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Repositories.TimeEntryRepo;

public interface ITimeEntryRepository
{
    TimeEntry? GetTimeEntryById(int id);
    List<TimeEntry> GetAllTimeEntries();
    List<TimeEntry> CreateNewTimeEntry(TimeEntry timeEntry);
    List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry);
    List<TimeEntry>? DeleteTimeEntry(int id);
}