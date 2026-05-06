using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace HospitalApi.Controllers
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
        // Retorna todos los departamentos con total, disponibles y ocupadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cama>>> GetCamas()
        {
            return await _context.Camas.ToListAsync();
        }

        // GET: api/camas/5
        // Retorna un departamento específico por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cama>> GetCama(int id)
        {
            var cama = await _context.Camas.FindAsync(id);

            if (cama == null)
                return NotFound(new { mensaje = $"No se encontró el departamento con ID {id}" });

            return cama;
        }

        // GET: api/camas/resumen
        // Resumen general: total camas, disponibles y ocupadas en todo el hospital
        [HttpGet("resumen")]
        public async Task<IActionResult> GetResumen()
        {
            var camas = await _context.Camas.ToListAsync();

            return Ok(new
            {
                TotalCamas = camas.Sum(c => c.CantidadCamas),
                TotalDisponibles = camas.Sum(c => c.CamasDisponibles),
                TotalOcupadas = camas.Sum(c => c.CamasOcupadas),
                PorDepartamento = camas.Select(c => new
                {
                    c.Departamento,
                    c.CantidadCamas,
                    c.CamasDisponibles,
                    c.CamasOcupadas
                })
            });
        }

        // PUT: api/camas/5
        // Actualiza todos los campos del departamento
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCama(int id, Cama cama)
        {
            if (id != cama.Id)
                return BadRequest(new { mensaje = "El ID de la URL no coincide con el ID del cuerpo." });

            if (cama.CamasDisponibles > cama.CantidadCamas)
                return BadRequest(new { mensaje = "Las camas disponibles no pueden superar el total de camas." });

            if (cama.CamasDisponibles < 0)
                return BadRequest(new { mensaje = "Las camas disponibles no pueden ser negativas." });

            _context.Entry(cama).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CamaExists(id))
                    return NotFound(new { mensaje = $"No se encontró el departamento con ID {id}" });

                throw;
            }

            return Ok(new { mensaje = "Actualizado correctamente.", datos = cama });
        }

        // PUT: api/camas/5/disponibles
        // Actualiza SOLO la cantidad de camas disponibles del departamento
        [HttpPut("{id}/disponibles")]
        public async Task<IActionResult> ActualizarDisponibles(int id, [FromBody] int camasDisponibles)
        {
            var cama = await _context.Camas.FindAsync(id);

            if (cama == null)
                return NotFound(new { mensaje = $"No se encontró el departamento con ID {id}" });

            if (camasDisponibles > cama.CantidadCamas)
                return BadRequest(new { mensaje = $"No puede haber más de {cama.CantidadCamas} camas disponibles en {cama.Departamento}." });

            if (camasDisponibles < 0)
                return BadRequest(new { mensaje = "Las camas disponibles no pueden ser negativas." });

            cama.CamasDisponibles = camasDisponibles;
            await _context.SaveChangesAsync();

            return Ok(new
            {
                mensaje = $"Disponibilidad de '{cama.Departamento}' actualizada.",
                datos = new
                {
                    cama.Departamento,
                    cama.CantidadCamas,
                    cama.CamasDisponibles,
                    cama.CamasOcupadas
                }
            });
        }

        private bool CamaExists(int id) =>
            _context.Camas.Any(e => e.Id == id);
    }
}