using TimeTracker.Shared.Entities;

namespace TimeTracker.API.Repositories.TimeEntryRepo;

public class TimeEntryRepository : ITimeEntryRepository
{
    private static List<TimeEntry> _timeEntries = new()
    {
        new TimeEntry
        {
            Id = 1,
            Project = "Time Tracker App",
            End = DateTime.Now.AddHours(1)
        }
    };
    public TimeEntry? GetTimeEntryById(int id)
    {
        return _timeEntries.FirstOrDefault(t => t.Id == id);
    }
    public List<TimeEntry> GetAllTimeEntries()
    {
        return _timeEntries;
    }

    public List<TimeEntry> CreateNewTimeEntry(TimeEntry timeEntry)
    {
        _timeEntries.Add(timeEntry);
        return _timeEntries;
    }

    public List<TimeEntry>? UpdateTimeEntry(int id, TimeEntry timeEntry)
    {
        var entryToUpdateIndex = _timeEntries.FindIndex(t => t.Id == id);
        if (entryToUpdateIndex == -1)
        {
            return null;
        }

        _timeEntries[entryToUpdateIndex] = timeEntry;
        return _timeEntries;
    }

    public List<TimeEntry>? DeleteTimeEntry(int id)
    {
        var entryToDeleteIndex = _timeEntries.FirstOrDefault(t => t.Id == id);
        if (entryToDeleteIndex is null)
        {
            return null;
        }

        _timeEntries.Remove(entryToDeleteIndex);
        return _timeEntries;
    }
}