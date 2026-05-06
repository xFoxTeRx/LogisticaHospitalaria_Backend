// Controllers/PedidosController.cs
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;

        public PedidosController(LogisticaHospitalariaContext context)
        {
            _context = context;
        }

        // GET: api/pedidos
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pedidos = await _context.PedidoAutomaticos
                .Include(p => p.Departamento)
                .Include(p => p.Detalles)
                .OrderByDescending(p => p.FechaGeneracion)
                .Select(p => new PedidoResponseDTO
                {
                    PedidoId = p.PedidoId,
                    FechaGeneracion = p.FechaGeneracion,
                    Estado = p.Estado.ToString(),
                    DepartamentoId = p.DepartamentoId,
                    Departamento = p.Departamento.Nombre,
                    Detalles = p.Detalles.Select(d => new DetalleResponseDTO
                    {
                        DetalleId = d.DetalleId,
                        ItemExternoId = d.ItemExternoId,
                        ItemNombre = d.ItemNombre,
                        CantidadSolicitada = d.CantidadSolicitada
                    }).ToList()
                })
                .ToListAsync();

            return Ok(pedidos);
        }

        // GET: api/pedidos/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var pedido = await _context.PedidoAutomaticos
                .Include(p => p.Departamento)
                .Include(p => p.Detalles)
                .Where(p => p.PedidoId == id)
                .Select(p => new PedidoResponseDTO
                {
                    PedidoId = p.PedidoId,
                    FechaGeneracion = p.FechaGeneracion,
                    Estado = p.Estado.ToString(),
                    DepartamentoId = p.DepartamentoId,
                    Departamento = p.Departamento.Nombre,
                    Detalles = p.Detalles.Select(d => new DetalleResponseDTO
                    {
                        DetalleId = d.DetalleId,
                        ItemExternoId = d.ItemExternoId,
                        ItemNombre = d.ItemNombre,
                        CantidadSolicitada = d.CantidadSolicitada
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (pedido == null)
                return NotFound($"Pedido con ID {id} no encontrado.");

            return Ok(pedido);
        }

        // PUT: api/pedidos/5/estado → solo cambia el estado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] PedidoEstadoDTO dto)
        {
            var pedido = await _context.PedidoAutomaticos.FindAsync(id);

            if (pedido == null)
                return NotFound($"Pedido con ID {id} no encontrado.");

            pedido.Estado = dto.Estado;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/pedidos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var pedido = await _context.PedidoAutomaticos.FindAsync(id);

            if (pedido == null)
                return NotFound($"Pedido con ID {id} no encontrado.");

            _context.PedidoAutomaticos.Remove(pedido);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("reabastecimiento")]
        public async Task<IActionResult> GenerarReabastecimiento()
        {
            using var client = new HttpClient();

            try
            {
                // 1. CONSUMIR LA API DE STOCKS ACTUALES
                var stocks = await client.GetFromJsonAsync<List<StockFarmaciaDTO>>("https://hospital3ernivel-farmacia.onrender.com/apiStocksActuales");

                if (stocks == null || !stocks.Any()) return BadRequest("No hay datos de stock disponibles.");

                // 2. FILTRAR: ¿Qué necesita reabastecimiento? 
                // Ejemplo: Si la cantidad es menor a 200, generamos pedido.
                var itemsBajos = stocks.Where(s => s.cantidadDisponible < 200).ToList();

                if (!itemsBajos.Any()) return Ok("El stock es suficiente. No se crearon pedidos.");

                // --- AQUÍ VA LA VALIDACIÓN ---
                // Verificamos si ya pedimos algo hoy para este departamento
                var hoy = DateTime.UtcNow.Date;
                var yaExistePedidoHoy = await _context.PedidoAutomaticos
                    .AnyAsync(p => p.DepartamentoId == 1 && p.FechaGeneracion.Date == hoy);

                if (yaExistePedidoHoy)
                {
                    return Ok(new { mensaje = "Ya se generó un reabastecimiento hoy. Esperando entrega para actualizar stock." });
                }

                // 3. CREAR EL PEDIDO (Asegúrate de que el DepartamentoId 1 exista en tu DB)
                var nuevoPedido = new PedidoAutomatico
                {
                    DepartamentoId = 36, // Cambia este ID por uno válido de tu tabla Departamentos
                    FechaGeneracion = DateTime.UtcNow,
                    Estado = LogisticaHospitalaria_Backend.Models.Enums.EstadoPedido.Generado
                };

                _context.PedidoAutomaticos.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                // 4. AGREGAR DETALLES
                foreach (var item in itemsBajos)
                {
                    var detalle = new PedidoDetalle
                    {
                        PedidoId = nuevoPedido.PedidoId,
                        ItemNombre = $"{item.medicamentoNombre} ({item.concentracion})",
                        CantidadSolicitada = 500 // Pedimos 500 para rellenar el stock
                    };
                    _context.PedidoDetalles.Add(detalle);
                }

                await _context.SaveChangesAsync();

                return Ok(new
                {
                    mensaje = "Reabastecimiento generado por bajo stock",
                    itemsSolicitados = itemsBajos.Select(i => i.medicamentoNombre),
                    pedidoId = nuevoPedido.PedidoId
                });
            }
            catch (Exception ex)
            {
                var mensajeReal = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                return StatusCode(500, $"Error: {mensajeReal}");
            }
        }

        // DTO ajustado a tu nuevo JSON
        public class StockFarmaciaDTO
        {
            public string? medicamentoNombre { get; set; }
            public string? concentracion { get; set; }
            public int cantidadDisponible { get; set; }
        }
    }
}