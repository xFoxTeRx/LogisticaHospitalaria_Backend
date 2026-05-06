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

        // POST: api/Pedidos/reabastecimiento
        [HttpPost("reabastecimiento")]
        public async Task<IActionResult> GenerarReabastecimiento()
        {
            using var client = new HttpClient();

            try
            {
                // 1. Obtener catálogo externo
                var catalogo = await client.GetFromJsonAsync<List<MedicamentoFarmaciaDTO>>("https://hospital3ernivel-farmacia.onrender.com/api/Medicamentos/catalogo");

                if (catalogo == null || !catalogo.Any()) return BadRequest("No se pudo obtener datos de la farmacia.");

                // 2. Crear la cabecera del pedido para Logística (ID 36 o el que tengas)
                var nuevoPedido = new PedidoAutomatico
                {
                    DepartamentoId = 36, // Ajusta este ID al de tu dpto de Logística
                    FechaGeneracion = DateTime.Now,
                    // Asegúrate de que el nombre del Enum sea el correcto según tu carpeta Enums
                    Estado = LogisticaHospitalaria_Backend.Models.Enums.EstadoPedido.Generado
                };

                _context.PedidoAutomaticos.Add(nuevoPedido);
                await _context.SaveChangesAsync();

                // 3. Llenar los detalles con lo que trajimos de Render
                foreach (var med in catalogo.Take(5)) // Tomamos 5 para probar
                {
                    var detalle = new PedidoDetalle
                    {
                        PedidoId = nuevoPedido.PedidoId,
                        ItemNombre = $"{med.nombreGenerico} - {med.nombreComercial}",
                        CantidadSolicitada = 100
                    };
                    _context.PedidoDetalles.Add(detalle);
                }

                await _context.SaveChangesAsync();

                return Ok(new { mensaje = "Reabastecimiento generado", pedidoId = nuevoPedido.PedidoId });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error de conexión: {ex.Message}");
            }
        }

        // Pon esta clase pequeña aquí mismo, al final del controlador (fuera de los métodos)
        public class MedicamentoFarmaciaDTO
        {
            public string? codigo { get; set; }
            public string? nombreGenerico { get; set; }
            public string? nombreComercial { get; set; }
        }
    }
}