// Models/Usuario.cs
using LogisticaHospitalaria_Backend.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace LogisticaHospitalaria_Backend.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [EmailAddress, MaxLength(150)]
        public string? Email { get; set; }

        public RolUsuario Rol { get; set; } = RolUsuario.Administrador;
    }
}