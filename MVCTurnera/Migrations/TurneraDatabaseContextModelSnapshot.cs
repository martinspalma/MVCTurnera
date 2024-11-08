﻿// <auto-generated />
using System;
using MVCTurnera.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVCTurnera.Migrations
{
    [DbContext(typeof(TurneraDatabaseContext))]
    partial class TurneraDatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVCTurnera.Models.Afiliado", b =>
                {
                    b.Property<int>("IdAfiliado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAfiliado"));

                    b.Property<string>("Dni")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("telefono")
                        .HasColumnType("int");

                    b.Property<int>("tipoPlan")
                        .HasColumnType("int");

                    b.HasKey("IdAfiliado");

                    b.ToTable("Afiliados");
                });

            modelBuilder.Entity("MVCTurnera.Models.Cita", b =>
                {
                    b.Property<int>("IdCita")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCita"));

                    b.Property<int?>("PrestadorMedicoIdPrestador")
                        .HasColumnType("int");

                    b.Property<bool>("estaDisponible")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("fechaCita")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("horaCita")
                        .HasColumnType("time");

                    b.HasKey("IdCita");

                    b.HasIndex("PrestadorMedicoIdPrestador");

                    b.ToTable("Agenda");
                });

            modelBuilder.Entity("MVCTurnera.Models.PrestadorMedico", b =>
                {
                    b.Property<int>("IdPrestador")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPrestador"));

                    b.Property<int>("DireccionAltura")
                        .HasColumnType("int");

                    b.Property<int>("DireccionCP")
                        .HasColumnType("int");

                    b.Property<string>("DireccionCalle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DireccionLocalidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Especialidad")
                        .HasColumnType("int");

                    b.Property<string>("MailMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MatriculaProfesional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreCompleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TelefonoMedico")
                        .HasColumnType("int");

                    b.HasKey("IdPrestador");

                    b.ToTable("Medicos");
                });

            modelBuilder.Entity("MVCTurnera.Models.Turno", b =>
                {
                    b.Property<int>("IdTurno")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTurno"));

                    b.Property<int>("AfiliadoIdAfiliado")
                        .HasColumnType("int");

                    b.Property<int>("CitaIdCita")
                        .HasColumnType("int");

                    b.Property<string>("MailMedico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicoIdPrestador")
                        .HasColumnType("int");

                    b.Property<int>("TelefonoMedico")
                        .HasColumnType("int");

                    b.HasKey("IdTurno");

                    b.HasIndex("AfiliadoIdAfiliado");

                    b.HasIndex("CitaIdCita");

                    b.HasIndex("MedicoIdPrestador");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("MVCTurnera.Models.Cita", b =>
                {
                    b.HasOne("MVCTurnera.Models.PrestadorMedico", null)
                        .WithMany("Agenda")
                        .HasForeignKey("PrestadorMedicoIdPrestador");
                });

            modelBuilder.Entity("MVCTurnera.Models.Turno", b =>
                {
                    b.HasOne("MVCTurnera.Models.Afiliado", "Afiliado")
                        .WithMany()
                        .HasForeignKey("AfiliadoIdAfiliado")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCTurnera.Models.Cita", "Cita")
                        .WithMany()
                        .HasForeignKey("CitaIdCita")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCTurnera.Models.PrestadorMedico", "Medico")
                        .WithMany()
                        .HasForeignKey("MedicoIdPrestador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Afiliado");

                    b.Navigation("Cita");

                    b.Navigation("Medico");
                });

            modelBuilder.Entity("MVCTurnera.Models.PrestadorMedico", b =>
                {
                    b.Navigation("Agenda");
                });
#pragma warning restore 612, 618
        }
    }
}
