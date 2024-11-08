using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCTurnera.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afiliados",
                columns: table => new
                {
                    IdAfiliado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dni = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tipoPlan = table.Column<int>(type: "int", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afiliados", x => x.IdAfiliado);
                });

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    IdPrestador = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad = table.Column<int>(type: "int", nullable: false),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MatriculaProfesional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMedico = table.Column<int>(type: "int", nullable: false),
                    DireccionCalle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionAltura = table.Column<int>(type: "int", nullable: false),
                    DireccionCP = table.Column<int>(type: "int", nullable: false),
                    DireccionLocalidad = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.IdPrestador);
                });

            migrationBuilder.CreateTable(
                name: "Agenda",
                columns: table => new
                {
                    IdCita = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fechaCita = table.Column<DateOnly>(type: "date", nullable: false),
                    horaCita = table.Column<TimeOnly>(type: "time", nullable: false),
                    estaDisponible = table.Column<bool>(type: "bit", nullable: false),
                    PrestadorMedicoIdPrestador = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agenda", x => x.IdCita);
                    table.ForeignKey(
                        name: "FK_Agenda_Medicos_PrestadorMedicoIdPrestador",
                        column: x => x.PrestadorMedicoIdPrestador,
                        principalTable: "Medicos",
                        principalColumn: "IdPrestador");
                });

            migrationBuilder.CreateTable(
                name: "Turnos",
                columns: table => new
                {
                    IdTurno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicoIdPrestador = table.Column<int>(type: "int", nullable: false),
                    MailMedico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoMedico = table.Column<int>(type: "int", nullable: false),
                    CitaIdCita = table.Column<int>(type: "int", nullable: false),
                    AfiliadoIdAfiliado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turnos", x => x.IdTurno);
                    table.ForeignKey(
                        name: "FK_Turnos_Afiliados_AfiliadoIdAfiliado",
                        column: x => x.AfiliadoIdAfiliado,
                        principalTable: "Afiliados",
                        principalColumn: "IdAfiliado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Agenda_CitaIdCita",
                        column: x => x.CitaIdCita,
                        principalTable: "Agenda",
                        principalColumn: "IdCita",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Turnos_Medicos_MedicoIdPrestador",
                        column: x => x.MedicoIdPrestador,
                        principalTable: "Medicos",
                        principalColumn: "IdPrestador",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agenda_PrestadorMedicoIdPrestador",
                table: "Agenda",
                column: "PrestadorMedicoIdPrestador");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_AfiliadoIdAfiliado",
                table: "Turnos",
                column: "AfiliadoIdAfiliado");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_CitaIdCita",
                table: "Turnos",
                column: "CitaIdCita");

            migrationBuilder.CreateIndex(
                name: "IX_Turnos_MedicoIdPrestador",
                table: "Turnos",
                column: "MedicoIdPrestador");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turnos");

            migrationBuilder.DropTable(
                name: "Afiliados");

            migrationBuilder.DropTable(
                name: "Agenda");

            migrationBuilder.DropTable(
                name: "Medicos");
        }
    }
}
