namespace LogisticaHospitalaria_Backend.DTOs
{
    public class StockExternoDTO
    {
        public string CodigoInsumo { get; set; }
        public string NombreInsumo { get; set; }
        public string CodigoAlmacen { get; set; }
        public string NombreAlmacen { get; set; }
        public int Entradas { get; set; }
        public int Salidas { get; set; }
        public int StockActual { get; set; }
    }

    // Lo que devuelve Operaciones
    // El objeto raíz que devuelve la API
    public class CamasResponseDTO
    {
        public int TotalCamas { get; set; }
        public List<CamaExternaDTO> Registros { get; set; } = new();
    }

    // Cada cama dentro del array
    public class CamaExternaDTO
    {
        public string Codigo { get; set; } = string.Empty;
        public int Cantidad { get; set; }
    }
}
