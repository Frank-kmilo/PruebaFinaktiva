using Microsoft.EntityFrameworkCore;
using PruebaFinaktiva.Api.Interfaces;
using PruebaFinaktiva.Data;
using PruebaFinaktiva.Data.Entities;


namespace PruebaFinaktiva.Api.Repository
{
    public class EventLogRepository : IEventLogProvider
    {
        private readonly DataContext _context;

        public EventLogRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<EventLog>> GetAllAsync()
        {
            return await _context.EventLogs.ToListAsync();
        }

        public async Task<string> AddLogAsync(EventLog eventLog)
        {
            try
            {
                _ = await _context.EventLogs.AddAsync(eventLog);
                _ = _context.SaveChanges();
                return "Registro guardado con exito";
            }
            catch (Exception)
            {
                return "[Error:] Ocurrio un error al guardar el registro, intentelo mas tarde o comuniquiese con el administrador del sistema";
            }
        }

        public async Task<List<EventLog>> GetEventsByFilters(string type, DateTime dateStart, DateTime dateEnd)
        {
            return await _context.EventLogs.Where(x => x.EventType == type &&
                                                  x.EventDate >= dateStart &&
                                                  x.EventDate >= dateEnd).ToListAsync();
        }
    }
}
