using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class DetalleSolicitud
    {
        [Key]
        public int DetalleId { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();

        public string ItemNombre { get; set; } = string.Empty;
        public int? Cantidad { get; set; }        // nullable — Servicios no tienen cantidad
        public string? Unidad { get; set; }
        public string? Observacion { get; set; }

        // FK
        public int SolicitudId { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
