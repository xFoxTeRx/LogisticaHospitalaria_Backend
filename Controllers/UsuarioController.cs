// Controllers/UsuarioController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Models.Enums;
using LogisticaHospitalaria_Backend.DTOs;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;

        public UsuarioController(LogisticaHospitalariaContext context)
        {
            _context = context;
        }

        // GET: api/usuario
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var usuarios = await _context.Usuarios
                .Select(u => new
                {
                    u.UsuarioId,
                    u.Nombre,
                    u.Email,
                    Rol = u.Rol.ToString()
                })
                .ToListAsync();

            return Ok(usuarios);
        }

        // GET: api/usuario/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound($"Usuario con ID {id} no encontrado.");

            return Ok(new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Email,
                Rol = usuario.Rol.ToString()
            });
        }

        // POST: api/usuario
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UsuarioCreateDTO dto)
        {
            var usuario = new Usuario
            {
                Nombre = dto.Nombre,
                Email = dto.Email,
                Rol = dto.Rol
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = usuario.UsuarioId }, new
            {
                usuario.UsuarioId,
                usuario.Nombre,
                usuario.Email,
                Rol = usuario.Rol.ToString()
            });
        }

        // PUT: api/usuario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UsuarioUpdateDTO dto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound($"Usuario con ID {id} no encontrado.");

            usuario.Nombre = dto.Nombre;
            usuario.Email = dto.Email;
            usuario.Rol = dto.Rol;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
                return NotFound($"Usuario con ID {id} no encontrado.");

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}