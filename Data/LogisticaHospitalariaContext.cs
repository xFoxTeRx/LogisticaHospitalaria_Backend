using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Models;

namespace LogisticaHospitalaria_Backend.Data
{
    public class LogisticaHospitalariaContext : DbContext
    {
        public LogisticaHospitalariaContext(DbContextOptions<LogisticaHospitalariaContext> options) : base(options) { }

        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<TipoSolicitud> TiposSolicitud { get; set; }
        public DbSet<TipoDepartamento> TiposDepartamento { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<HistorialSolicitud> HistorialSolicitudes { get; set; }
        public DbSet<WebhookSuscriptor> WebhookSuscriptores { get; set; }
        public DbSet<DetalleSolicitud> DetallesSolicitud { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Solicitud → dos FK a Usuario
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Usuario)
                .WithMany(u => u.Solicitudes)
                .HasForeignKey(s => s.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.UsuarioResponsable)
                .WithMany()
                .HasForeignKey(s => s.UsuarioResponsableId)
                .OnDelete(DeleteBehavior.Restrict);

            // Solicitud → dos FK a Departamento
            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.Departamento)
                .WithMany(d => d.Solicitudes)
                .HasForeignKey(s => s.DepartamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Solicitud>()
                .HasOne(s => s.DepartamentoDestino)
                .WithMany()
                .HasForeignKey(s => s.DepartamentoDestinoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Historial → FK a Usuario
            modelBuilder.Entity<HistorialSolicitud>()
                .HasOne(h => h.Usuario)
                .WithMany(u => u.Historiales)
                .HasForeignKey(h => h.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed — 36 departamentos
            modelBuilder.Entity<Departamento>().HasData(
                new Departamento { DepartamentoId = 1, Nombre = "Gestión de Pacientes" },
                new Departamento { DepartamentoId = 2, Nombre = "Emergencias y Triaje" },
                new Departamento { DepartamentoId = 3, Nombre = "Consultas Externas" },
                new Departamento { DepartamentoId = 4, Nombre = "Hospitalización" },
                new Departamento { DepartamentoId = 5, Nombre = "Cuidados Críticos" },
                new Departamento { DepartamentoId = 6, Nombre = "Gestión Quirúrgica" },
                new Departamento { DepartamentoId = 7, Nombre = "Especialidades Médicas" },
                new Departamento { DepartamentoId = 8, Nombre = "Diagnóstico Clínico" },
                new Departamento { DepartamentoId = 9, Nombre = "Diagnóstico por Imágenes" },
                new Departamento { DepartamentoId = 10, Nombre = "Farmacia Hospitalaria" },
                new Departamento { DepartamentoId = 11, Nombre = "Terapias y Rehabilitación" },
                new Departamento { DepartamentoId = 12, Nombre = "Maternidad y Neonatología" },
                new Departamento { DepartamentoId = 13, Nombre = "Gestión de Enfermería" },
                new Departamento { DepartamentoId = 14, Nombre = "Gestión de Turnos y Citas" },
                new Departamento { DepartamentoId = 15, Nombre = "Facturación y Seguros" },
                new Departamento { DepartamentoId = 16, Nombre = "Recursos Humanos" },
                new Departamento { DepartamentoId = 17, Nombre = "Gestión Financiera" },
                new Departamento { DepartamentoId = 18, Nombre = "Compras y Abastecimiento" },
                new Departamento { DepartamentoId = 19, Nombre = "Gestión de Inventarios" },
                new Departamento { DepartamentoId = 20, Nombre = "Mantenimiento y Activos" },
                new Departamento { DepartamentoId = 21, Nombre = "Soporte Técnico TI" },
                new Departamento { DepartamentoId = 22, Nombre = "Gestión de Calidad" },
                new Departamento { DepartamentoId = 23, Nombre = "Bioseguridad y Control Sanitario" },
                new Departamento { DepartamentoId = 24, Nombre = "Investigación Clínica" },
                new Departamento { DepartamentoId = 25, Nombre = "Docencia y Capacitación" },
                new Departamento { DepartamentoId = 26, Nombre = "Gestión Legal" },
                new Departamento { DepartamentoId = 27, Nombre = "Atención al Paciente" },
                new Departamento { DepartamentoId = 28, Nombre = "Telemedicina" },
                new Departamento { DepartamentoId = 29, Nombre = "Analítica y Reportes BI" },
                new Departamento { DepartamentoId = 30, Nombre = "Seguridad y Accesos" },
                new Departamento { DepartamentoId = 31, Nombre = "Interoperabilidad e Integración" },
                new Departamento { DepartamentoId = 32, Nombre = "Gestión Documental" },
                new Departamento { DepartamentoId = 33, Nombre = "Logística Hospitalaria" },
                new Departamento { DepartamentoId = 34, Nombre = "Gestión de Ambulancias" },
                new Departamento { DepartamentoId = 35, Nombre = "Control Epidemiológico" },
                new Departamento { DepartamentoId = 36, Nombre = "Psicología" }
            );

            // Seed — Tipos de solicitud
            modelBuilder.Entity<TipoSolicitud>().HasData(
                new TipoSolicitud { TipoSolicitudId = 1, Nombre = "Insumos Médicos", Categoria = "Insumo" },
                new TipoSolicitud { TipoSolicitudId = 2, Nombre = "Medicamentos", Categoria = "Insumo" },
                new TipoSolicitud { TipoSolicitudId = 3, Nombre = "Equipamiento", Categoria = "Insumo" },
                new TipoSolicitud { TipoSolicitudId = 4, Nombre = "Mantenimiento", Categoria = "Servicio" },
                new TipoSolicitud { TipoSolicitudId = 5, Nombre = "Traslado de Materiales", Categoria = "Traslado" },
                new TipoSolicitud { TipoSolicitudId = 6, Nombre = "Reunión", Categoria = "Servicio" },
                new TipoSolicitud { TipoSolicitudId = 7, Nombre = "Permiso", Categoria = "Servicio" }
            );
        }
    }
}