// Models/PedidoDetalle.cs
using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class PedidoDetalle
    {
        [Key]
        public int DetalleId { get; set; }

        [Required]
        public string ItemExternoId { get; set; } = string.Empty;

        [Required, MaxLength(200)]
        public string ItemNombre { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int CantidadSolicitada { get; set; }

        public int PedidoId { get; set; }
        public PedidoAutomatico Pedido { get; set; } = null!;
    }
}