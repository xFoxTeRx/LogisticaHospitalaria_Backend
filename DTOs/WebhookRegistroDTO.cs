public class WebhookRegistroDTO
{
    public string NombreSistema { get; set; } = string.Empty;
    public string UrlCallback { get; set; } = string.Empty;

    // ❌ te faltaba esto
    public string DepartamentoNombre { get; set; } = string.Empty;
}