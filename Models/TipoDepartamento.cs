using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    // Define qué tipos de solicitud puede HACER cada departamento
    // Ej: Quirúrgica puede pedir "Material Quirúrgico" pero no "Mantenimiento de Red"
    public class TipoDepartamento
    {
        [Key]
        public int TipoDepartamentoId { get; set; }

        public int TipoSolicitudId { get; set; }        // FK → TipoSolicitud
        public TipoSolicitud TipoSolicitud { get; set; }

        public int DepartamentoDuenoId { get; set; }    // FK → Departamento
        public Departamento DepartamentoDueno { get; set; }
    }
}