using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Codigo { get; set; } = string.Empty; // Ej: 'LOG-033'

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        // Nuevo campo solicitado
        [MaxLength(500)]
        public string? Descripcion { get; set; }

        public string? Ubicacion { get; set; }

        public bool Activo { get; set; } = true;

        // Relaciones (Propiedades de navegación)
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
        public virtual ICollection<PedidoAutomatico> Pedidos { get; set; } = new List<PedidoAutomatico>();
    }
}