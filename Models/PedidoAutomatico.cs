using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class PedidoAutomatico
    {
        [Key]
        public int PedidoId { get; set; }
        public DateTime FechaGeneracion { get; set; } = DateTime.Now;
        public string Estado { get; set; } = "Generado";

        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; } = null!;

        public virtual ICollection<PedidoDetalle> Detalles { get; set; } = new List<PedidoDetalle>();
    }
}
