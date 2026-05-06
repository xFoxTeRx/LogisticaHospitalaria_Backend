// Models/Departamento.cs
using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Departamento
    {
        [Key]
        public int DepartamentoId { get; set; }

        [Required, MaxLength(20)]
        public string Codigo { get; set; } = string.Empty;

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(500)]
        public string? Descripcion { get; set; }

        [MaxLength(200)]
        public string? Ubicacion { get; set; }

        public bool Activo { get; set; } = true;

        public ICollection<PedidoAutomatico> Pedidos { get; set; } = new List<PedidoAutomatico>();
    }
}