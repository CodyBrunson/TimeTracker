﻿namespace TimeTracker.API.Services;

public interface ITimeEntryService
{
    Task<TimeEntryResponse?> GetTimeEntryById(int id);
    Task<List<TimeEntryResponse>> GetAllTimeEntries();
    Task<List<TimeEntryResponse>> CreateNewTimeEntry(TimeEntryCreateRequest request);
    List<TimeEntryResponse>? UpdateTimeEntry(int id, TimeEntryUpdateRequest request);
    
    List<TimeEntryResponse>? DeleteTimeEntry(int id);
}