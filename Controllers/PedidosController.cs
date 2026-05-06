using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;

        public PedidosController(LogisticaHospitalariaContext context)
        {
            _context = context;
        }

        // GET: api/Pedidos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoAutomatico>>> GetPedidos()
        {
            return await _context.PedidoAutomaticos
                .Include(p => p.Departamento)
                .Include(p => p.Detalles) // Trae los insumos del pedido
                .OrderByDescending(p => p.FechaGeneracion)
                .ToListAsync();
        }

        // POST: api/Pedidos (Para crear un pedido nuevo)
        [HttpPost]
        public async Task<ActionResult<PedidoAutomatico>> PostPedido(PedidoAutomatico pedido)
        {
            _context.PedidoAutomaticos.Add(pedido);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPedidos), new { id = pedido.PedidoId }, pedido);
        }

        // PUT: api/Pedidos/5 (Para cambiar el estado a "Enviado" o "Recibido")
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPedido(int id, PedidoAutomatico pedido)
        {
            if (id != pedido.PedidoId) return BadRequest();

            _context.Entry(pedido).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
