// Models/PedidoAutomatico.cs
using LogisticaHospitalaria_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class PedidoAutomatico
    {
        [Key]
        public int PedidoId { get; set; }

        public DateTime FechaGeneracion { get; set; } = DateTime.UtcNow;

        public EstadoPedido Estado { get; set; } = EstadoPedido.Generado;

        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; } = null!;

        public ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}