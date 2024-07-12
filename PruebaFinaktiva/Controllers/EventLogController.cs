using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaFinaktiva.Api.Interfaces;
using PruebaFinaktiva.Data.Entities;

namespace PruebaFinaktiva.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogProvider _eventLogProvider;

        public EventLogController(IEventLogProvider eventLogProvider)
        {
            _eventLogProvider = eventLogProvider;
        }

        [HttpPost]
        [Route("add-log")]
        public async Task<ActionResult> AddLog(EventLog eventLog)
        {
            string response = await _eventLogProvider.AddLogAsync(eventLog);

            return response.Contains("[Error:]") ?
                StatusCode(500, response.Replace("[Error:]", string.Empty)) :
                Ok(response);
        }

        [HttpGet]
        [Route("Get-Events")]
        public async Task<ActionResult> GetEventsByFilters([FromQuery] string? type,
                                                           [FromQuery] DateTime? startDate,
                                                           [FromQuery] DateTime? endDate)
        {
            List<EventLog> eventLogs;
            if (string.IsNullOrEmpty(type) || startDate == null || endDate == null)
            {
                eventLogs = await _eventLogProvider.GetAllAsync();
            }
            else
            {
                eventLogs = await _eventLogProvider.GetEventsByFilters(type, startDate, endDate.Value.AddDays(1));
            }
            return Ok(eventLogs);
        }
    }
}
