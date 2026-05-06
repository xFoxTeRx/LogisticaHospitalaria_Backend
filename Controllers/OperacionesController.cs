// Controllers/OperacionesController.cs
using Microsoft.AspNetCore.Mvc;
using LogisticaHospitalaria_Backend.DTOs;
using System.Text.Json;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperacionesController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private const string API_URL = "http://0.0.0.0:5003/api/MisOperaciones/total-camas";

        public OperacionesController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        // GET: api/operaciones/camas
        [HttpGet("camas")]
        public async Task<IActionResult> GetCamas()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de operaciones.");

            var json = await response.Content.ReadAsStringAsync();
            var camas = JsonSerializer.Deserialize<CamasResponseDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(camas);
        }

        // GET: api/operaciones/camas/resumen
        [HttpGet("camas/resumen")]
        public async Task<IActionResult> GetResumen()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de operaciones.");

            var json = await response.Content.ReadAsStringAsync();
            var camas = JsonSerializer.Deserialize<CamasResponseDTO>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(new
            {
                camas!.TotalCamas,
                TotalAreas = camas.Registros.Count,
                Areas = camas.Registros.OrderByDescending(c => c.Cantidad)
            });
        }
    }
}