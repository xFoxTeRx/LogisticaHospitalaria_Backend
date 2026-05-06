namespace LogisticaHospitalaria_Backend.Models
{
    namespace HospitalApi.Models
    {
        public class Cama
        {
            public int Id { get; set; }
            public string Departamento { get; set; } = string.Empty;
            public int CantidadCamas { get; set; }
        }
    }

}
