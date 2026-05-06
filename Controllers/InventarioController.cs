// Controllers/InventarioController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.Enums;
using System.Text.Json;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly LogisticaHospitalariaContext _context;
        private const string API_URL = "https://gestor-inventario-h-production.up.railway.app/api/MisInventario/stock-actual";
        private const int STOCK_MINIMO = 20;

        public InventarioController(IHttpClientFactory httpClientFactory, LogisticaHospitalariaContext context)
        {
            _httpClient = httpClientFactory.CreateClient();
            _context = context;
        }

        // GET: api/inventario/stock
        [HttpGet("stock")]
        public async Task<IActionResult> GetStock()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de inventario.");

            var json = await response.Content.ReadAsStringAsync();
            var stock = JsonSerializer.Deserialize<List<StockExternoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return Ok(stock);
        }

        // GET: api/inventario/bajo-stock
        [HttpGet("bajo-stock")]
        public async Task<IActionResult> GetBajoStock()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de inventario.");

            var json = await response.Content.ReadAsStringAsync();
            var stock = JsonSerializer.Deserialize<List<StockExternoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var bajoStock = stock?
                .Where(s => s.StockActual < STOCK_MINIMO)
                .Select(s => new
                {
                    s.CodigoInsumo,
                    s.NombreInsumo,
                    s.CodigoAlmacen,
                    s.NombreAlmacen,
                    s.StockActual,
                    StockMinimo = STOCK_MINIMO,
                    CantidadAReponer = STOCK_MINIMO - s.StockActual
                });

            return Ok(bajoStock);
        }

        // POST: api/inventario/reponer
        [HttpPost("reponer")]
        public async Task<IActionResult> Reponer()
        {
            var response = await _httpClient.GetAsync(API_URL);
            if (!response.IsSuccessStatusCode)
                return StatusCode(502, "Error al conectar con la API de inventario.");

            var json = await response.Content.ReadAsStringAsync();
            var stock = JsonSerializer.Deserialize<List<StockExternoDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            var bajoStock = stock?.Where(s => s.StockActual < STOCK_MINIMO).ToList();

            if (bajoStock == null || !bajoStock.Any())
                return Ok("No hay insumos bajo stock mínimo.");

            // Agrupar por almacen → un pedido por departamento
            var porAlmacen = bajoStock.GroupBy(s => s.CodigoAlmacen);
            var pedidosGenerados = new List<object>();

            foreach (var grupo in porAlmacen)
            {
                var departamento = await _context.Departamentos
                    .FirstOrDefaultAsync(d => d.Codigo == grupo.Key);

                if (departamento == null) continue;

                var pedido = new PedidoAutomatico
                {
                    DepartamentoId = departamento.DepartamentoId,
                    FechaGeneracion = DateTime.UtcNow,
                    Estado = EstadoPedido.Generado,
                    Detalles = grupo.Select(i => new PedidoDetalle
                    {
                        ItemExternoId = i.CodigoInsumo,
                        ItemNombre = i.NombreInsumo,
                        CantidadSolicitada = STOCK_MINIMO - i.StockActual
                    }).ToList()
                };

                _context.PedidoAutomaticos.Add(pedido);
                pedidosGenerados.Add(new
                {
                    Almacen = grupo.Key,
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