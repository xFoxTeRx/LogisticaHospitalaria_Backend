using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Solicitud
    {
        [Key]
        public int SolicitudId { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();

        public string Estado { get; set; } = "Pendiente";
        public string Prioridad { get; set; } = "Normal";
        public string? Observaciones { get; set; }

        // Solo para Traslados
        public int? DepartamentoDestinoId { get; set; }
        public Departamento? DepartamentoDestino { get; set; }

        // Solo para Servicios/Reuniones
        public DateTime? FechaRequerida { get; set; }

        // Fechas del ciclo de vida
        public DateTime FechaSolicitud { get; set; } = DateTime.UtcNow;
        public DateTime? FechaAceptacion { get; set; }
        public DateTime? FechaEntrega { get; set; }

        // FK
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        public int TipoSolicitudId { get; set; }
        public TipoSolicitud TipoSolicitud { get; set; }

        public int? UsuarioResponsableId { get; set; }
        public Usuario? UsuarioResponsable { get; set; }

        // Relaciones
        public ICollection<DetalleSolicitud> Detalles { get; set; } = new List<DetalleSolicitud>();
        public ICollection<HistorialSolicitud> Historiales { get; set; } = new List<HistorialSolicitud>();
    }
}