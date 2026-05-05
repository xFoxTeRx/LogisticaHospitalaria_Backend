using LogisticaHospitalaria_Backend.DTOs;
using System.Text.Json;

namespace LogisticaHospitalaria_Backend.Services
{
    public class GestionInventarioService    
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<GestionInventarioService> _logger;

        public GestionInventarioService(IHttpClientFactory factory, ILogger<GestionInventarioService> logger)
        {
            _httpClientFactory = factory;
            _logger = logger;
        }

        // Consultar stock de inventarios
        public async Task<List<StockExternoDTO>> ObtenerStockAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("http://10.77.200.28:5003/api/MisInventario/stock-actual");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<StockExternoDTO>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando stock externo");
                return new List<StockExternoDTO>();
            }
        }

        // Consultar camas disponibles
        public async Task<CamasResponseDTO> ObtenerCamasAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("http://10.77.200.28:5003/api/MisOperaciones/total-camas");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<CamasResponseDTO>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error consultando camas externas");
                return new CamasResponseDTO();
            }
        }
    }
}
