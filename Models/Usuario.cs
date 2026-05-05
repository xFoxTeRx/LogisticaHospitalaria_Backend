using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        public string Rol { get; set; } = "Administrador"; // 'Admin', 'Operador'

        // FK a Departamentos
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; } = null!;
    }
}