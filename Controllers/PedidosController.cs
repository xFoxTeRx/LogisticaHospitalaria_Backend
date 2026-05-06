// Controllers/PedidosController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models.Enums;

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
    }
}