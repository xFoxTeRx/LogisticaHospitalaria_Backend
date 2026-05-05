using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class WebhookSuscriptor
    {
        [Key]
        public int WebhookId { get; set; }
        public string NombreSistema { get; set; } = string.Empty;  // "Farmacia", "Quirurgica"
        public string UrlCallback { get; set; } = string.Empty;    // donde les avisás
        public string? SecretoFirma { get; set; }                  // seguridad (luego)
        public bool Activo { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

        // A qué departamento pertenece
        public int DepartamentoId { get; set; }
        public Departamento Departamento { get; set; }
    }
}
