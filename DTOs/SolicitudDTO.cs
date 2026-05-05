namespace LogisticaHospitalaria_Backend.DTOs
{
    public class SolicitudDTO
    {
        public Guid PublicId { get; set; }
        public string Estado { get; set; } = string.Empty;
        public string Prioridad { get; set; } = string.Empty;
        public string? Observaciones { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaRequerida { get; set; }
        public DateTime? FechaCompletado { get; set; }
        public string UsuarioNombre { get; set; } = string.Empty;
        public string TipoSolicitudNombre { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string DepartamentoNombre { get; set; } = string.Empty;
        public string? DepartamentoDestinoNombre { get; set; }
        public List<DetalleItemDTO> Items { get; set; } = new();
    }
}