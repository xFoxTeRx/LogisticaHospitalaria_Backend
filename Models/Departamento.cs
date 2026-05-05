using LogisticaHospitalaria_Backend.Models;
using System.ComponentModel.DataAnnotations;

public class Departamento
{
    [Key]
    public int DepartamentoId { get; set; }
    public Guid PublicId { get; set; } = Guid.NewGuid();
    public string Codigo { get; set; } = string.Empty;  // ← nuevo
    public string Nombre { get; set; } = string.Empty;
    public string? Descripcion { get; set; }
    public string? Ubicacion { get; set; }
    public bool Activo { get; set; } = true;

    public ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    public ICollection<TipoDepartamento> TiposDepartamento { get; set; } = new List<TipoDepartamento>();
    public ICollection<Solicitud> Solicitudes { get; set; } = new List<Solicitud>();
}