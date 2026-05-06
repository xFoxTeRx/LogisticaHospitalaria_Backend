// DTOs/AmbulanciaDTO.cs
namespace LogisticaHospitalaria_Backend.DTOs
{
    // Lo que devuelve la API externa
    public class AmbulanciaExternaDTO
    {
        public string CodigoAmbulancia { get; set; } = string.Empty;
        public string TipoAmbulancia { get; set; } = string.Empty;
        public string Estado { get; set; } = string.Empty;
        public DateTime FechaConsulta { get; set; }
        public List<InsumoAmbulanciaDTO> Insumos { get; set; } = new();
        public ResumenAmbulanciaDTO Resumen { get; set; } = new();
    }

    public class InsumoAmbulanciaDTO
    {
        public string CodigoInsumo { get; set; } = string.Empty;
        public string NombreInsumo { get; set; } = string.Empty;
        public string UnidadMedida { get; set; } = string.Empty;
        public int CantidadRequerida { get; set; }
        public int CantidadActual { get; set; }
        public int Diferencia { get; set; }
        public string EstadoInsumo { get; set; } = string.Empty;
        public bool EsCritico { get; set; }
        public int CantidadAReponer { get; set; }
    }

    public class ResumenAmbulanciaDTO
    {
        public int TotalInsumosRequeridos { get; set; }
        public int TotalInsumosActuales { get; set; }
        public int TotalFaltantes { get; set; }
        public int TotalCriticos { get; set; }
        public bool RequiereReposicionUrgente { get; set; }
        public string Mensaje { get; set; } = string.Empty;
    }
}