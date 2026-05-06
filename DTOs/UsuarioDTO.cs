// DTOs/UsuarioDTO.cs
using LogisticaHospitalaria_Backend.Models.Enums;

namespace LogisticaHospitalaria_Backend.DTOs
{
    public class UsuarioCreateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Email { get; set; }
        public RolUsuario Rol { get; set; } = RolUsuario.Administrador;
    }

    public class UsuarioUpdateDTO
    {
        public string Nombre { get; set; } = string.Empty;
        public string? Email { get; set; }
        public RolUsuario Rol { get; set; }
    }
}