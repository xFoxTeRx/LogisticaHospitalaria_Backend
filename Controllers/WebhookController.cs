using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WebhooksController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _db;

        public WebhooksController(LogisticaHospitalariaContext db) => _db = db;

        // Compañero se registra una vez con su URL
        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] WebhookRegistroDTO dto)
        {
            var depto = await _db.Departamentos
                .FirstOrDefaultAsync(d => d.Nombre.ToLower() == dto.DepartamentoNombre.ToLower());

            if (depto == null)
                return BadRequest($"Departamento '{dto.DepartamentoNombre}' no existe");

            var existente = await _db.WebhookSuscriptores
                .FirstOrDefaultAsync(w => w.DepartamentoId == depto.DepartamentoId);

            if (existente != null)
            {
                existente.UrlCallback = dto.UrlCallback;
                existente.NombreSistema = dto.NombreSistema;
                existente.Activo = true;
            }
            else
            {
                _db.WebhookSuscriptores.Add(new WebhookSuscriptor
                {
                    NombreSistema = dto.NombreSistema,
                    UrlCallback = dto.UrlCallback,
                    DepartamentoId = depto.DepartamentoId,
                    Activo = true
                });
            }

            await _db.SaveChangesAsync();
            return Ok(new { Mensaje = $"Webhook registrado para {dto.NombreSistema}" });
        }

        // Ver quiénes están suscritos
        [HttpGet]
        public async Task<IActionResult> Listar()
        {
            var suscriptores = await _db.WebhookSuscriptores
                .Include(w => w.Departamento)
                .Select(w => new {
                    w.NombreSistema,
                    w.UrlCallback,
                    Departamento = w.Departamento.Nombre,
                    w.Activo,
                    w.FechaRegistro
                })
                .ToListAsync();

            return Ok(suscriptores);
        }
    }
}