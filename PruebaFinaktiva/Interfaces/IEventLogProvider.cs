using PruebaFinaktiva.Data.Entities;

namespace PruebaFinaktiva.Api.Interfaces
{
    public interface IEventLogProvider
    {
        Task<List<EventLog>> GetAllAsync();

        Task<string> AddLogAsync(EventLog eventLog);

        Task<List<EventLog>> GetEventsByFilters(string? type, DateTime? startDate, DateTime? endDate);
    }
}
