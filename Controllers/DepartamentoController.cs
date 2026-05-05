using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartamentosController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;
        public DepartamentosController(LogisticaHospitalariaContext context) => _context = context;

        [HttpPost]
        public async Task<IActionResult> CrearDepartamento([FromBody] Departamento dto)
        {
            _context.Departamentos.Add(dto);
            await _context.SaveChangesAsync();
            return Ok(dto);
        }

        [HttpGet]
        public async Task<IActionResult> GetDepartamentos()
        {
            var query = from d in _context.Departamentos
                        where d.Activo == true
                        orderby d.Nombre
                        select new
                        {
                            d.Codigo,
                            d.Nombre,
                            d.Descripcion,
                            d.Ubicacion
                        };

            return Ok(await query.ToListAsync());
        }


        // MIS: cantidad de solicitudes por departamento
        [HttpGet("solicitudes-count")]
        public async Task<IActionResult> GetSolicitudesCount()
        {
            var query = from s in _context.Solicitudes
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        group s by d.Nombre into g
                        select new { Departamento = g.Key, Cantidad = g.Count() };
            return Ok(await query.ToListAsync());
        }
    }
}
