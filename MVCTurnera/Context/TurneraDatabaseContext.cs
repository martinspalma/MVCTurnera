
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MVCTurnera.Models;

namespace MVCTurnera.Context
{
    public class TurneraDatabaseContext : DbContext
    {
        public TurneraDatabaseContext(DbContextOptions<TurneraDatabaseContext> options) : base(options)
        {
        }
        public DbSet<Afiliado> Afiliados { get; set; }
        public DbSet<PrestadorMedico> Medicos { get; set; }
        public DbSet<Cita> Agenda { get; set; }
        public DbSet<Turno> Turnos { get; set; }
    }
}


