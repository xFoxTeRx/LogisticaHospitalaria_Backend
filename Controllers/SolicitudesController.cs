using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;
using LogisticaHospitalaria_Backend.DTOs;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Services;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolicitudesController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _db;
        private readonly WebhookService _webhookService;

        public SolicitudesController(LogisticaHospitalariaContext db, WebhookService webhookService)
        {
            _db = db;
            _webhookService = webhookService;
        }

        // ─── CREAR ──────────────────────────────────────────
        [HttpPost]
        public async Task<IActionResult> CrearSolicitud([FromBody] SolicitudCreateDTO dto)
        {
            // 1. Buscar departamento
            var departamento = await _db.Departamentos
                .FirstOrDefaultAsync(d => d.Nombre.ToLower() == dto.DepartamentoNombre.ToLower());

            if (departamento == null)
                return BadRequest($"Departamento '{dto.DepartamentoNombre}' no existe");

            // 2. Buscar tipo solicitud
            var tipoSolicitud = await _db.TiposSolicitud
                .FirstOrDefaultAsync(t => t.Nombre.ToLower() == dto.TipoSolicitudNombre.ToLower());

            if (tipoSolicitud == null)
                return BadRequest($"Tipo de solicitud '{dto.TipoSolicitudNombre}' no existe");

            // 3. Validar según categoría
            if (tipoSolicitud.Categoria == "Insumo" && (dto.Items == null || !dto.Items.Any()))
                return BadRequest("Las solicitudes de insumos requieren al menos un item");

            if (tipoSolicitud.Categoria == "Traslado" && string.IsNullOrEmpty(dto.DepartamentoDestinoNombre))
                return BadRequest("Los traslados requieren departamento destino");

            // 4. Buscar o crear usuario
            var usuario = await _db.Usuarios
                .FirstOrDefaultAsync(u => u.Email.ToLower() == dto.UsuarioEmail.ToLower());

            if (usuario == null)
            {
                usuario = new Usuario
                {
                    Nombre = dto.UsuarioNombre,
                    Email = dto.UsuarioEmail,
                    Rol = "Solicitante",
                    DepartamentoId = departamento.DepartamentoId,
                    Activo = true
                };
                _db.Usuarios.Add(usuario);
                await _db.SaveChangesAsync();
            }

            // 5. Buscar departamento destino si es traslado
            int? deptoDestinoId = null;
            if (tipoSolicitud.Categoria == "Traslado")
            {
                var deptoDestino = await _db.Departamentos
                    .FirstOrDefaultAsync(d => d.Nombre.ToLower() == dto.DepartamentoDestinoNombre!.ToLower());

                if (deptoDestino == null)
                    return BadRequest($"Departamento destino '{dto.DepartamentoDestinoNombre}' no existe");

                deptoDestinoId = deptoDestino.DepartamentoId;
            }

            // 6. Crear solicitud
            var solicitud = new Solicitud
            {
                Prioridad = dto.Prioridad,
                Observaciones = dto.Observaciones,
                FechaSolicitud = DateTime.UtcNow,
                Estado = "Pendiente",
                FechaRequerida = dto.FechaRequerida.HasValue ?
                    DateTime.SpecifyKind(dto.FechaRequerida.Value, DateTimeKind.Utc)
                    : null,
                UsuarioId = usuario.UsuarioId,
                DepartamentoId = departamento.DepartamentoId,
                TipoSolicitudId = tipoSolicitud.TipoSolicitudId,
                DepartamentoDestinoId = deptoDestinoId
            };

            _db.Solicitudes.Add(solicitud);
            await _db.SaveChangesAsync();

            // 7. Guardar items si hay
            if (dto.Items != null && dto.Items.Any())
            {
                foreach (var item in dto.Items)
                {
                    _db.DetallesSolicitud.Add(new DetalleSolicitud
                    {
                        SolicitudId = solicitud.SolicitudId,
                        ItemNombre = item.ItemNombre,
                        Cantidad = item.Cantidad,
                        Unidad = item.Unidad,
                        Observacion = item.Observacion
                    });
                }
                await _db.SaveChangesAsync();
            }

            // 8. Historial
            _db.HistorialSolicitudes.Add(new HistorialSolicitud
            {
                SolicitudId = solicitud.SolicitudId,
                EstadoAnterior = "-",
                EstadoNuevo = "Pendiente",
                UsuarioId = usuario.UsuarioId,
                FechaCambio = DateTime.UtcNow,
                Observacion = "Solicitud creada"
            });
            await _db.SaveChangesAsync();

            return Ok(new { solicitud.PublicId, Estado = solicitud.Estado, Mensaje = "Solicitud registrada" });
        }

        // ─── LISTAR TODAS ───────────────────────────────────
        [HttpGet("todas")]
        public async Task<IActionResult> ListarSolicitudes()
        {
            var solicitudes = await _db.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Departamento)
                .Include(s => s.TipoSolicitud)
                .Include(s => s.DepartamentoDestino)
                .Include(s => s.Detalles)
                .OrderBy(s => s.FechaSolicitud)
                .Select(s => new SolicitudDTO
                {
                    PublicId = s.PublicId,
                    Estado = s.Estado,
                    Prioridad = s.Prioridad,
                    Observaciones = s.Observaciones,
                    FechaSolicitud = s.FechaSolicitud,
                    FechaRequerida = s.FechaRequerida,
                    FechaCompletado = s.FechaEntrega,
                    UsuarioNombre = s.Usuario.Nombre,
                    TipoSolicitudNombre = s.TipoSolicitud.Nombre,
                    Categoria = s.TipoSolicitud.Categoria,
                    DepartamentoNombre = s.Departamento.Nombre,
                    DepartamentoDestinoNombre = s.DepartamentoDestino != null ? s.DepartamentoDestino.Nombre : null,
                    Items = s.Detalles.Select(d => new DetalleItemDTO
                    {
                        ItemNombre = d.ItemNombre,
                        Cantidad = d.Cantidad,
                        Unidad = d.Unidad,
                        Observacion = d.Observacion
                    }).ToList()
                })
                .ToListAsync();

            return Ok(solicitudes);
        }

        // ─── LISTAR POR ESTADO ──────────────────────────────
        [HttpGet("por-estado")]
        public async Task<IActionResult> ListarPorEstado([FromQuery] string estado)
        {
            var solicitudes = await _db.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Departamento)
                .Include(s => s.TipoSolicitud)
                .Include(s => s.Detalles)
                .Where(s => s.Estado == estado)
                .OrderBy(s => s.FechaSolicitud)
                .Select(s => new SolicitudDTO
                {
                    PublicId = s.PublicId,
                    Estado = s.Estado,
                    Prioridad = s.Prioridad,
                    Observaciones = s.Observaciones,
                    FechaSolicitud = s.FechaSolicitud,
                    FechaRequerida = s.FechaRequerida,
                    FechaCompletado = s.FechaEntrega,
                    UsuarioNombre = s.Usuario.Nombre,
                    TipoSolicitudNombre = s.TipoSolicitud.Nombre,
                    Categoria = s.TipoSolicitud.Categoria,
                    DepartamentoNombre = s.Departamento.Nombre,
                    Items = s.Detalles.Select(d => new DetalleItemDTO
                    {
                        ItemNombre = d.ItemNombre,
                        Cantidad = d.Cantidad,
                        Unidad = d.Unidad,
                        Observacion = d.Observacion
                    }).ToList()
                })
                .ToListAsync();

            return Ok(solicitudes);
        }

        // ─── OBTENER UNA ────────────────────────────────────
        [HttpGet("{publicId:guid}")]
        public async Task<IActionResult> ObtenerSolicitud(Guid publicId)
        {
            var s = await _db.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Departamento)
                .Include(s => s.TipoSolicitud)
                .Include(s => s.DepartamentoDestino)
                .Include(s => s.Detalles)
                .FirstOrDefaultAsync(s => s.PublicId == publicId);

            if (s == null) return NotFound();

            return Ok(new SolicitudDTO
            {
                PublicId = s.PublicId,
                Estado = s.Estado,
                Prioridad = s.Prioridad,
                Observaciones = s.Observaciones,
                FechaSolicitud = s.FechaSolicitud,
                FechaRequerida = s.FechaRequerida,
                FechaCompletado = s.FechaEntrega,
                UsuarioNombre = s.Usuario.Nombre,
                TipoSolicitudNombre = s.TipoSolicitud.Nombre,
                Categoria = s.TipoSolicitud.Categoria,
                DepartamentoNombre = s.Departamento.Nombre,
                DepartamentoDestinoNombre = s.DepartamentoDestino?.Nombre,
                Items = s.Detalles.Select(d => new DetalleItemDTO
                {
                    ItemNombre = d.ItemNombre,
                    Cantidad = d.Cantidad,
                    Unidad = d.Unidad,
                    Observacion = d.Observacion
                }).ToList()
            });
        }

        // ─── ACEPTAR ────────────────────────────────────────
        [HttpPatch("{publicId:guid}/aceptar")]
        public async Task<IActionResult> AceptarSolicitud(Guid publicId)
        {
            var solicitud = await ObtenerConIncludes(publicId);
            if (solicitud == null) return NotFound();
            if (solicitud.Estado != "Pendiente")
                return BadRequest("Solo se pueden aceptar solicitudes Pendientes");

            await CambiarEstado(solicitud, "Aceptada", 1);
            await _webhookService.NotificarCambioEstado(solicitud);
            return Ok(MapearDTO(solicitud));
        }

        // ─── RECHAZAR ───────────────────────────────────────
        [HttpPatch("{publicId:guid}/rechazar")]
        public async Task<IActionResult> RechazarSolicitud(Guid publicId, [FromBody] string motivo)
        {
            var solicitud = await ObtenerConIncludes(publicId);
            if (solicitud == null) return NotFound();
            if (solicitud.Estado != "Pendiente")
                return BadRequest("Solo se pueden rechazar solicitudes Pendientes");

            await CambiarEstado(solicitud, "Rechazada", 1, motivo);
            await _webhookService.NotificarCambioEstado(solicitud);
            return Ok(MapearDTO(solicitud));
        }

        // ─── ENTREGAR ───────────────────────────────────────
        [HttpPatch("{publicId:guid}/entregar")]
        public async Task<IActionResult> EntregarSolicitud(Guid publicId)
        {
            var solicitud = await ObtenerConIncludes(publicId);
            if (solicitud == null) return NotFound();
            if (solicitud.Estado != "Aceptada")
                return BadRequest("Solo se pueden entregar solicitudes Aceptadas");

            solicitud.FechaEntrega = DateTime.UtcNow;
            await CambiarEstado(solicitud, "Entregada", 1);
            await _webhookService.NotificarCambioEstado(solicitud);
            return Ok(MapearDTO(solicitud));
        }

        // ─── HELPERS ────────────────────────────────────────
        private async Task<Solicitud?> ObtenerConIncludes(Guid publicId) =>
            await _db.Solicitudes
                .Include(s => s.Usuario)
                .Include(s => s.Departamento)
                .Include(s => s.TipoSolicitud)
                .Include(s => s.DepartamentoDestino)
                .Include(s => s.Detalles)
                .FirstOrDefaultAsync(s => s.PublicId == publicId);

        private async Task CambiarEstado(Solicitud solicitud, string nuevoEstado,
            int usuarioId, string? observacion = null)
        {
            var estadoAnterior = solicitud.Estado;
            solicitud.Estado = nuevoEstado;

            if (nuevoEstado == "Aceptada")
                solicitud.FechaAceptacion = DateTime.UtcNow;

            _db.HistorialSolicitudes.Add(new HistorialSolicitud
            {
                SolicitudId = solicitud.SolicitudId,
                EstadoAnterior = estadoAnterior,
                EstadoNuevo = nuevoEstado,
                UsuarioId = usuarioId,
                FechaCambio = DateTime.UtcNow,
                Observacion = observacion
            });

            await _db.SaveChangesAsync();
        }

        private SolicitudDTO MapearDTO(Solicitud s) => new()
        {
            PublicId = s.PublicId,
            Estado = s.Estado,
            Prioridad = s.Prioridad,
            Observaciones = s.Observaciones,
            FechaSolicitud = s.FechaSolicitud,
            FechaRequerida = s.FechaRequerida,
            FechaCompletado = s.FechaEntrega,
            UsuarioNombre = s.Usuario.Nombre,
            TipoSolicitudNombre = s.TipoSolicitud.Nombre,
            Categoria = s.TipoSolicitud.Categoria,
            DepartamentoNombre = s.Departamento.Nombre,
            DepartamentoDestinoNombre = s.DepartamentoDestino?.Nombre,
            Items = s.Detalles.Select(d => new DetalleItemDTO
            {
                ItemNombre = d.ItemNombre,
                Cantidad = d.Cantidad,
                Unidad = d.Unidad,
                Observacion = d.Observacion
            }).ToList()
        };


    }
}