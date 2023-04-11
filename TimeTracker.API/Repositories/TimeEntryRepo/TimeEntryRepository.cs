namespace TimeTracker.API.Repositories.TimeEntryRepo;

public class TimeEntryRepository : ITimeEntryRepository
{

    private readonly DataContext _context;
    private static List<TimeEntry> _timeEntries = new()
    {
        new TimeEntry
        {
            Id = 1,
            Project = "Time Tracker App",
            End = DateTime.Now.AddHours(1)
        }
    };

    public TimeEntryRepository(DataContext context)
    {
        _context = context;
    }

    public TimeEntry? GetTimeEntryById(int id)
    {
        return _timeEntries.FirstOrDefault(t => t.Id == id);
    }
    public List<TimeEntry> GetAllTimeEntries()
    {
        return _timeEntries;
    }

    public async Task<List<TimeEntry>> CreateNewTimeEntry(TimeEntry timeEntry)
    {
        _context.TimeEntries.Add(timeEntry);
        await _context.SaveChangesAsync();

        return await _context.TimeEntries.ToListAsync();
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