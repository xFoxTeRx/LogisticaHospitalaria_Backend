using LogisticaHospitalaria_Backend.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GestionInventarioController : ControllerBase
    {
        private readonly GestionInventarioService _integracion;

        public GestionInventarioController(GestionInventarioService integracion)
        {
            _integracion = integracion;
        }

        // GET: todo el stock general
        [HttpGet("stock")]
        public async Task<IActionResult> GetStockGeneral()
        {
            var stock = await _integracion.ObtenerStockAsync();

            var resultado = stock.Select(s => new
            {
                s.NombreInsumo,
                s.StockActual,
                s.NombreAlmacen

            });

            return Ok(resultado);
        }


        // GET: solo camas
        [HttpGet("camas")]
        public async Task<IActionResult> GetCamass()
        {
            var camas = await _integracion.ObtenerCamasAsync();
            return Ok(camas);
        }


        [HttpGet("total-camas")]
        public async Task<IActionResult> GetCamas()
        {
            var resultado = await _integracion.ObtenerCamasAsync();

            return Ok(new
            {
                resultado.TotalCamas,
                resultado.Registros
            });
        }

        // GET: stock bajo — items con poco inventario
        [HttpGet("stock-bajo")]
        public async Task<IActionResult> GetStockBajo([FromQuery] int minimo = 20)
        {
            var stock = await _integracion.ObtenerStockAsync();

            var resultado = stock
                .Where(s => s.StockActual <= minimo)
                .OrderBy(s => s.StockActual)
                .Select(s => new
                {
                    s.NombreInsumo,
                    s.CodigoInsumo,
                    s.StockActual,
                    s.NombreAlmacen,
                    Alerta = s.StockActual == 0 ? "AGOTADO" : "BAJO"
                });

            return Ok(resultado);
        }

        // GET: buscar un insumo específico
        [HttpGet("stock/{nombreInsumo}")]
        public async Task<IActionResult> GetStockInsumo(string nombreInsumo)
        {
            var stock = await _integracion.ObtenerStockAsync();

            var insumo = stock.FirstOrDefault(s =>
                s.NombreInsumo.ToLower().Contains(nombreInsumo.ToLower()));

            if (insumo == null)
                return NotFound($"Insumo '{nombreInsumo}' no encontrado");

            return Ok(new
            {
                insumo.CodigoInsumo,
                insumo.NombreInsumo,
                insumo.StockActual,
                insumo.Entradas,
                insumo.Salidas,
                insumo.NombreAlmacen,
                HayStock = insumo.StockActual > 0
            });
        }


        // POST: generar pedido desde stock bajo
        [HttpPost("pedidos/generar")]
        public async Task<IActionResult> GenerarPedido([FromQuery] int minimo = 20)
        {
            var stock = await _integracion.ObtenerStockAsync();

            var items = stock
                .Where(s => s.StockActual <= minimo)
                .OrderBy(s => s.StockActual)
                .Select(s => new
                {
                    s.CodigoInsumo,
                    s.NombreInsumo,
                    s.NombreAlmacen,
                    s.StockActual,
                    CantidadSolicitada = minimo - s.StockActual+10
                });

            var pedido = new
            {
                FechaPedido = DateTime.Now.ToString("yyyy-MM-dd"),
                Urgencia = "URGENTE",
                Items = items
            };

            return Ok(pedido);
        }

        // POST: solicitar medicamentos al área de gestión
        [HttpPost("solicitar")]
        public async Task<IActionResult> SolicitarMedicamento(
            [FromQuery] string codigoInsumo,
            [FromQuery] int cantidad)
        {
            var stock = await _integracion.ObtenerStockAsync();

            var insumo = stock.FirstOrDefault(s => s.CodigoInsumo == codigoInsumo);

            if (insumo == null)
                return NotFound($"Insumo '{codigoInsumo}' no encontrado");

            var solicitud = new
            {
                CodigoPedido = $"SOL-{DateTime.Now:yyyyMMdd-HHmmss}",
                FechaSolicitud = DateTime.Now.ToString("yyyy-MM-dd"),
                CodigoInsumo = insumo.CodigoInsumo,
                NombreInsumo = insumo.NombreInsumo,
                NombreAlmacen = insumo.NombreAlmacen,
                StockActual = insumo.StockActual,
                CantidadSolicitada = cantidad,
                HayStock = insumo.StockActual >= cantidad ? "DISPONIBLE" : "INSUFICIENTE"
            };

            return Ok(solicitud);
        }
    }
}