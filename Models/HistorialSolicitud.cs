using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class HistorialSolicitud
    {
        [Key]
        public int HistorialId { get; set; }

        public DateTime FechaCambio { get; set; } = DateTime.UtcNow; // ← corregido
        public string EstadoAnterior { get; set; } = string.Empty;
        public string EstadoNuevo { get; set; } = string.Empty;
        public string? Observacion { get; set; }  // por qué cambió el estado

        // FK
        public int SolicitudId { get; set; }
        public Solicitud Solicitud { get; set; }

        public int UsuarioId { get; set; }          // quién hizo el cambio
        public Usuario Usuario { get; set; }
    }
}