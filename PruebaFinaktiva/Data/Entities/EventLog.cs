using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PruebaFinaktiva.Data.Entities
{
    public class EventLog
    {
        public int Id { get; set; }

        public string EventType { get; set; }

        public DateTime EventDate { get; set; }

        public string EventDescription { get; set; }
    }
}
