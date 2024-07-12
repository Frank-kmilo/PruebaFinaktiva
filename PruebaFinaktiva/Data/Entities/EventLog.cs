using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PruebaFinaktiva.Data.Entities
{
    public class EventLog
    {
        [JsonProperty]
        public int Id { get; set; }

        [Display(Name = "Tipo de evento")]
        [MaxLength(100, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public string EventType { get; set; }

        [Display(Name = "Fecha de evento")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public DateTime EventDate { get; set; }

        [Display(Name = "Descripción")]
        [MaxLength(500, ErrorMessage = "El campo {0} no puede tener mas de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [JsonProperty]
        public string EventDescription { get; set; }
    }
}
