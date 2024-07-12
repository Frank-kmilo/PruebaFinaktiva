using Microsoft.AspNetCore.Mvc;
using PruebaFinaktiva.Api.Interfaces;
using PruebaFinaktiva.Data.Entities;

namespace PruebaFinaktiva.Api.Controllers
{
    [Produces("aplication/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventLogController : ControllerBase
    {
        private readonly IEventLogProvider _eventLogProvider;

        public EventLogController(IEventLogProvider eventLogProvider)
        {
            _eventLogProvider = eventLogProvider;
        }


        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult> GetAllAsync()
        {
            List<EventLog> eventLogs = await _eventLogProvider.GetAllAsync();
            return Ok(eventLogs);
        }

        [HttpPost]
        [Route("add-log")]
        public async Task<ActionResult> AddLog(EventLog eventLog)
        {
            string response = await _eventLogProvider.AddLogAsync(eventLog);

            return response.Contains("[Error:]") ?
                StatusCode(500, $"Ocurrió un error: {response.Replace("[Error:]", string.Empty)}") :
                Ok(response);
        }


        [HttpGet]
        [Route("Get/{type}/{dateStart}/{dateEnd}")]
        public async Task<ActionResult> GetEventsByFilters(string type, DateTime dateStart, DateTime dateEnd)
        {
            List<EventLog> eventLogs = await _eventLogProvider.GetEventsByFilters(type, dateStart, dateEnd);
            return Ok(eventLogs);
        }
    }
}
