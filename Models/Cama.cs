namespace LogisticaHospitalaria_Backend.Models
{
    public class Cama
    {
        public int Id { get; set; }
        public string Departamento { get; set; } = string.Empty;

        // Total de camas del departamento
        public int CantidadCamas { get; set; }

        // Cuántas están disponibles actualmente
        public int CamasDisponibles { get; set; }

        // Calculado: no se guarda en BD
        public int CamasOcupadas => CantidadCamas - CamasDisponibles;
    }
}