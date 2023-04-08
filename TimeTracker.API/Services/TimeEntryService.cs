﻿using Mapster;
using TimeTracker.API.Repositories.TimeEntryRepo;
using TimeTracker.Shared.Entities;
using TimeTracker.Shared.Models.TimeEntry;

namespace TimeTracker.API.Services;

public class TimeEntryService : ITimeEntryService
{
    private readonly ITimeEntryRepository _timeEntryRepository;

    public TimeEntryService(ITimeEntryRepository timeEntryRepository)
    {
        _timeEntryRepository = timeEntryRepository;
    }

    public TimeEntryResponse GetTimeEntryById(int id)
    {
        var result = _timeEntryRepository.GetTimeEntryById(id);
        if (result is null)
        {
            return null;
        }

        return result.Adapt<TimeEntryResponse>();
    }

    public List<TimeEntryResponse> GetAllTimeEntries()
    {
        var result = _timeEntryRepository.GetAllTimeEntries();
        return result.Adapt<List<TimeEntryResponse>>();
    }

    public List<TimeEntryResponse> CreateNewTimeEntry(TimeEntryCreateRequest request)
    {
        var newEntry = request.Adapt<TimeEntry>();
        var result = _timeEntryRepository.CreateNewTimeEntry(newEntry);
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