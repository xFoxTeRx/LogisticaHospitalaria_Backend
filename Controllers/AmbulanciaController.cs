// Controllers/AmbulanciaController.cs
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AmbulanciaController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly LogisticaHospitalariaContext _context;
        private const string API_URL = "https://gestionambulancia-production.up.railway.app/api/AmbulanciaInsumo/situacion-actual";

        public AmbulanciaController(IHttpClientFactory httpClientFactory, LogisticaHospitalariaContext context)
        {
            _httpClient = httpClientFactory.CreateClient();
            _context = context;
        }

        // GET: api/ambulancia/situacion
        [HttpGet("situacion")]
        public async Task<IActionResult> GetSituacion()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de ambulancias.");

            var json = await response.Content.ReadAsStringAsync();
            var ambulancias = JsonSerializer.Deserialize<List<AmbulanciaExternaDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(ambulancias);
        }

        // GET: api/ambulancia/criticos
        [HttpGet("criticos")]
        public async Task<IActionResult> GetCriticos()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de ambulancias.");

            var json = await response.Content.ReadAsStringAsync();
            var ambulancias = JsonSerializer.Deserialize<List<AmbulanciaExternaDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var criticos = ambulancias?
                .Where(a => a.Resumen.RequiereReposicionUrgente)
                .Select(a => new
                {
                    a.CodigoAmbulancia,
                    a.TipoAmbulancia,
                    a.Estado,
                    InsumosCriticos = a.Insumos.Where(i => i.EsCritico).ToList(),
                    a.Resumen.TotalCriticos,
                    a.Resumen.TotalFaltantes,
                    a.Resumen.Mensaje
                });

            return Ok(criticos);
        }

        // POST: api/ambulancia/reponer
        [HttpPost("reponer")]
        public async Task<IActionResult> Reponer()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de ambulancias.");

            var json = await response.Content.ReadAsStringAsync();
            var ambulancias = JsonSerializer.Deserialize<List<AmbulanciaExternaDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var criticas = ambulancias?.Where(a => a.Resumen.RequiereReposicionUrgente).ToList();

            if (criticas == null || !criticas.Any())
                return Ok("No hay ambulancias que requieran reposición.");

            var pedidosGenerados = new List<object>();

            foreach (var ambulancia in criticas)
            {
                // Buscar departamento por codigo de ambulancia
                var departamento = await _context.Departamentos
                    .FirstOrDefaultAsync(d => d.Codigo == ambulancia.CodigoAmbulancia);

                if (departamento == null) continue;

                var pedido = new PedidoAutomatico
                {
                    DepartamentoId = departamento.DepartamentoId,
                    FechaGeneracion = DateTime.UtcNow,
                    Estado = EstadoPedido.Generado,
                    Detalles = ambulancia.Insumos
                        .Where(i => i.CantidadAReponer > 0)
                        .Select(i => new PedidoDetalle
                        {
                            ItemExternoId = i.CodigoInsumo,
                            ItemNombre = i.NombreInsumo,
                            CantidadSolicitada = i.CantidadAReponer
                        }).ToList()
                };

                _context.PedidoAutomaticos.Add(pedido);
                pedidosGenerados.Add(new
                {
                    ambulancia.CodigoAmbulancia,
                    TotalInsumos = pedido.Detalles.Count
                });
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Mensaje = $"Se generaron {pedidosGenerados.Count} pedidos de reposición.",
                Pedidos = pedidosGenerados
            });
        }
    }
}