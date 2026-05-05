using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   // identificador único
        public string Rol { get; set; } = string.Empty;

        // Referencia al sistema de RRHH — no exponés tu ID interno
        public string? ReferenciaRRHH { get; set; }         // el id/codigo que maneja RRHH

        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // FK
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }

        // Relaciones
        public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
        public ICollection<HistorialSolicitud> Historiales { get; set; } = new List<HistorialSolicitud>();
    }
}