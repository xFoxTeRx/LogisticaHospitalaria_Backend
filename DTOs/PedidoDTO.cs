// DTOs/PedidoDTO.cs
using LogisticaHospitalaria_Backend.Models.Enums;

namespace LogisticaHospitalaria_Backend.DTOs
{
    public class PedidoResponseDTO
    {
        public int PedidoId { get; set; }
        public DateTime FechaGeneracion { get; set; }
        public string Estado { get; set; } = string.Empty;
        public int DepartamentoId { get; set; }
        public string Departamento { get; set; } = string.Empty;
        public List<DetalleResponseDTO> Detalles { get; set; } = new();
    }

    public class DetalleResponseDTO
    {
        public int DetalleId { get; set; }
        public string ItemExternoId { get; set; } = string.Empty;
        public string ItemNombre { get; set; } = string.Empty;
        public int CantidadSolicitada { get; set; }
    }

    public class PedidoEstadoDTO
    {
        public EstadoPedido Estado { get; set; }
    }
}