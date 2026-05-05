using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;
        public UsuariosController(LogisticaHospitalariaContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> CrearUsuario([FromBody] Usuario dto)
        {
            _context.Usuarios.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var query = from u in _context.Usuarios
                        join d in _context.Departamentos on u.DepartamentoId equals d.DepartamentoId
                        select new
                        {
                            UsuarioId = u.UsuarioId,
                            UsuarioNombre = u.Nombre,
                            DepartamentoNombre = d.Nombre
                        };
            return Ok(await query.ToListAsync());
        }

        // MIS: solicitudes por usuario
        [HttpGet("solicitudes")]
        public async Task<IActionResult> GetSolicitudesPorUsuario()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        group s by u.Nombre into g
                        select new { Usuario = g.Key, CantidadSolicitudes = g.Count() };
            return Ok(await query.ToListAsync());
        }
    }
}
