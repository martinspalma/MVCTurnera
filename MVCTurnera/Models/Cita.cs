using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTurnera.Models
{
    public class Cita
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCita { get; set; }

        [Display(Name = "Fecha cita")]
        public DateOnly fechaCita { get; set; }
        
        [Display(Name = "Hora cita")]
        public TimeOnly horaCita { get; set; }

        public Boolean estaDisponible { get; set; }

    }
}
