using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MVCTurnera.Models
{
    public class PrestadorMedico
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPrestador { get; set; }
        [EnumDataType(typeof(Especialidad))]
        public Especialidad Especialidad { get; set; }
        public string NombreCompleto { get; set; }
        public string MatriculaProfesional { get; set; }
        public string MailMedico { get; set; }
        public int TelefonoMedico { get; set; }
        public string DireccionCalle { get; set; }
        public int DireccionAltura { get; set; }
        public int DireccionCP { get; set; }
        public string DireccionLocalidad { get; set; }
        public List<Cita>? Agenda { get; set; }
       


    }

    
}
