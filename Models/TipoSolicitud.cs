using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class TipoSolicitud
    {
        [Key]
        public int TipoSolicitudId { get; set; }
        public Guid PublicId { get; set; } = Guid.NewGuid();

        public string Nombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty; // Insumo, Servicio, Traslado
        public bool Activo { get; set; } = true;

        // Relaciones
        public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
        public ICollection<TipoDepartamento> TiposDepartamento { get; set; } = new List<TipoDepartamento>();
    }
}   