namespace LogisticaHospitalaria_Backend.DTOs
{
    public class SolicitudCreateDTO
    {
        public string UsuarioNombre { get; set; } = string.Empty;
        public string UsuarioEmail { get; set; } = string.Empty;
        public string TipoSolicitudNombre { get; set; } = string.Empty;
        public string DepartamentoNombre { get; set; } = string.Empty;
        public string Prioridad { get; set; } = "Normal";
        public string? Observaciones { get; set; }

        // Solo Insumos/Traslados
        public List<DetalleItemDTO>? Items { get; set; }

        // Solo Servicios/Reuniones
        public DateTime? FechaRequerida { get; set; }

        // Solo Traslados
        public string? DepartamentoDestinoNombre { get; set; }
    }

    public class DetalleItemDTO
    {
        public string ItemNombre { get; set; } = string.Empty;
        public int? Cantidad { get; set; }
        public string? Unidad { get; set; }
        public string? Observacion { get; set; }
    }

}
