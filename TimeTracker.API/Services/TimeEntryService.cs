﻿using Mapster;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository;

    public TimeEntryService(ITimeEntryRepository timeEntryRepository)
    {
        _timeEntryRepository = timeEntryRepository;
    }

    public async Task<TimeEntryResponse?> GetTimeEntryById(int id)
    {
        var result = await _timeEntryRepository.GetTimeEntryById(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<TimeEntryResponse>();
    }

    public async Task<List<TimeEntryResponse>> GetAllTimeEntries()
    {
        var result = await _timeEntryRepository.GetAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public async Task<List<TimeEntryResponse>> CreateNewTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = await _timeEntryRepository.CreateNewTimeEntry(newEntry);
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest request)
    {
        var updatedEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepository.UpdateTimeEntry(id, updatedEntry);
        if (result is null)
        {
            return null;
        }
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse>? DeleteTimeEntry(int id)
    {
        var result = _timeEntryRepository.DeleteTimeEntry(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<List<TimeEntryResponse>>();
    }
}