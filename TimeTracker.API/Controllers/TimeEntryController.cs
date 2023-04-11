﻿using Microsoft.AspNetCore.Mvc;

namespace TimeTracker.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TimeEntryController : ControllerBase
{
    private readonly ITimeEntryService _timeEntryService;

    public TimeEntryController(ITimeEntryService timeEntryService)
    {
        _timeEntryService = timeEntryService;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TimeEntryResponse>> GetTimeEntryById(int id)
    {
        var result = await _timeEntryService.GetTimeEntryById(id);
        if (result is null)
        {
            return NotFound("TimeEntry with ID " + id + " does not exist.");
        }

        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<TimeEntryResponse>>> GetAllTimeEntries()
    {
        return Ok(await _timeEntryService.GetAllTimeEntries());
    }

    [HttpPost]
    public async Task<ActionResult<List<TimeEntryResponse>>> CreateTimeEntry(TimeEntryCreateRequest timeEntry)
    {
        return Ok(await _timeEntryService.CreateNewTimeEntry(timeEntry));
    }

    [HttpPut("{id}")]
    public ActionResult<List<TimeEntryResponse>> UpdateTimeEntry(int id, TimeEntryUpdateRequest timeEntry)
    {
        var result = _timeEntryService.UpdateTimeEntry(id, timeEntry);
        if (result is null)
        {
            return NotFound("TimeEntry with ID " + id + " does not exist.");
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<List<TimeEntryResponse>> DeleteTimeEntry(int id)
    {
        var result = _timeEntryService.DeleteTimeEntry(id);
        if (result is null)
        {
            return NotFound("TimeEntry with ID " + id + " does not exist.");
        }

        return Ok(result);
    }
}