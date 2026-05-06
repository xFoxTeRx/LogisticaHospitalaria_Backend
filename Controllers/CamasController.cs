using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.HospitalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CamasController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;

        public CamasController(LogisticaHospitalariaContext context)
        {
            _context = context;
        }

        // GET: api/camas
        // Retorna todas las camas con su departamento y cantidad
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cama>>> GetCamas()
        {
            return await _context.Camas.ToListAsync();
        }

        // GET: api/camas/5
        // Retorna una cama específica por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cama>> GetCama(int id)
        {
            var cama = await _context.Camas.FindAsync(id);

            if (cama == null)
                return NotFound(new { mensaje = $"No se encontró cama con ID {id}" });

            return cama;
        }

        // PUT: api/camas/5
        // Actualiza la cantidad de camas de un departamento
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCama(int id, Cama cama)
        {
            if (id != cama.Id)
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cuerpo." });

            _context.Entry(cama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamaExists(id))
                    return NotFound(new { mensaje = $"No se encontró cama con ID {id}" });

                throw;
            }

            return Ok(new { mensaje = "Cama actualizada correctamente.", datos = cama });
        }

        private bool CamaExists(int id) =>
            _context.Camas.Any(e => e.Id == id);
    }
}