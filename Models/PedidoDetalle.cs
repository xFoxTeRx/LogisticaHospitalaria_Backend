using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class PedidoDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        [Required]
        public string ItemNombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public int PedidoId { get; set; }
        public virtual PedidoAutomatico Pedido { get; set; } = null!;
    }
}
