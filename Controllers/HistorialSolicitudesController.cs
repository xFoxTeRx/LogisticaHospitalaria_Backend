using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.DTOs;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HistorialSolicitudController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;
        public HistorialSolicitudController(LogisticaHospitalariaContext context) => _context = context;

        // POST: api/HistorialSolicitud
        [HttpPost]
        public async Task<IActionResult> CrearHistorial([FromBody] HistorialSolicitud dto)
        {
            dto.FechaCambio = DateTime.UtcNow;
            _context.HistorialSolicitudes.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        // GET: api/HistorialSolicitud
        [HttpGet]
        public async Task<IActionResult> GetHistorial()
        {
            var query = from h in _context.HistorialSolicitudes
                        join u in _context.Usuarios on h.UsuarioId equals u.UsuarioId
                        select new
                        {
                            HistorialId = h.HistorialId,
                            SolicitudId = h.SolicitudId,
                            EstadoAnterior = h.EstadoAnterior,
                            EstadoNuevo = h.EstadoNuevo,
                            FechaCambio = h.FechaCambio,
                            UsuarioNombre = u.Nombre
                        };
            return Ok(await query.ToListAsync());
        }

        // MIS: historial por solicitud
        [HttpGet("por-solicitud/{id:int}")]
        public async Task<IActionResult> GetHistorialPorSolicitud(int id)
        {
            var query = from h in _context.HistorialSolicitudes
                        join u in _context.Usuarios on h.UsuarioId equals u.UsuarioId
                        where h.SolicitudId == id
                        orderby h.FechaCambio descending
                        select new
                        {
                            h.SolicitudId,
                            h.EstadoAnterior,
                            h.EstadoNuevo,
                            h.FechaCambio,
                            UsuarioNombre = u.Nombre
                        };
            return Ok(await query.ToListAsync());
        }

        // MIS: cantidad de cambios por usuario
        [HttpGet("cambios-por-usuario")]
        public async Task<IActionResult> GetCambiosPorUsuario()
        {
            var query = from h in _context.HistorialSolicitudes
                        join u in _context.Usuarios on h.UsuarioId equals u.UsuarioId
                        group h by u.Nombre into g
                        select new
                        {
                            Usuario = g.Key,
                            CantidadCambios = g.Count()
                        };
            return Ok(await query.ToListAsync());
        }
    }
}
