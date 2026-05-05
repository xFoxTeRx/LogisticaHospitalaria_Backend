using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Services
{
    public class WebhookService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly LogisticaHospitalariaContext _db;
        private readonly ILogger<WebhookService> _logger;

        public WebhookService(IHttpClientFactory factory, LogisticaHospitalariaContext db, ILogger<WebhookService> logger)
        {
            _httpClientFactory = factory;
            _db = db;
            _logger = logger;
        }

        public async Task NotificarCambioEstado(Solicitud solicitud)
        {
            var suscriptores = await _db.WebhookSuscriptores
                .Where(w => w.DepartamentoId == solicitud.DepartamentoId && w.Activo)
                .ToListAsync();

            if (!suscriptores.Any())
            {
                _logger.LogWarning("Sin webhooks para departamento {Id}", solicitud.DepartamentoId);
                return;
            }

            var payload = new
            {
                publicId = solicitud.PublicId,
                estado = solicitud.Estado,
                mensaje = $"Tu solicitud cambió a: {solicitud.Estado}",
                fechaCambio = DateTime.UtcNow,
                departamento = solicitud.Departamento?.Nombre,
                usuarioNombre = solicitud.Usuario?.Nombre
            };

            // Notificar a todos en paralelo
            var tareas = suscriptores.Select(s => EnviarNotificacion(s, payload));
            await Task.WhenAll(tareas);
        }

        private async Task EnviarNotificacion(WebhookSuscriptor suscriptor, object payload)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.Timeout = TimeSpan.FromSeconds(10); // no esperés más de 10 seg

                var response = await client.PostAsJsonAsync(suscriptor.UrlCallback, payload);

                if (response.IsSuccessStatusCode)
                    _logger.LogInformation("✅ Webhook OK → {Sistema}", suscriptor.NombreSistema);
                else
                    _logger.LogWarning("⚠️ Webhook falló → {Sistema} | Status: {Status}",
                        suscriptor.NombreSistema, response.StatusCode);
            }
            catch (Exception ex)
            {
                // Si el compañero está caído, tu sistema sigue funcionando
                _logger.LogError(ex, "❌ Error webhook → {Sistema}", suscriptor.NombreSistema);
            }
        }
    }
}