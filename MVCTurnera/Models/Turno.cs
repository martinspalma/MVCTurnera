using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVCTurnera.Models
{
    public class Turno
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdTurno { get; set; }
        public PrestadorMedico Medico { get; set; }
        public string MailMedico { get; set; }
        public int TelefonoMedico { get; set; }
        public Cita Cita { get; set; }

        public Afiliado Afiliado { get; set; }
    }
}
