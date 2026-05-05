using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Data;

namespace LogisticaHospitalaria_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MisController : ControllerBase
    {
        private readonly LogisticaHospitalariaContext _context;

        public MisController(LogisticaHospitalariaContext context) => _context = context;

        // ════════════════════════════════════════════════
        // CONSULTAS GENÉRICAS OBLIGATORIAS (5)
        // ════════════════════════════════════════════════

        // 1. JOIN — Listado general de solicitudes
        [HttpGet("listado-general")]
        public async Task<IActionResult> ListadoGeneral()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        join t in _context.TiposSolicitud on s.TipoSolicitudId equals t.TipoSolicitudId
                        orderby s.FechaSolicitud descending
                        select new
                        {
                            s.PublicId,
                            s.Estado,
                            s.Prioridad,
                            s.FechaSolicitud,
                            Usuario = u.Nombre,
                            Departamento = d.Nombre,
                            TipoSolicitud = t.Nombre,
                            Categoria = t.Categoria
                        };

            return Ok(await query.ToListAsync());
        }

        // 2. GROUP BY + COUNT — Solicitudes por departamento
        [HttpGet("solicitudes-por-departamento")]
        public async Task<IActionResult> SolicitudesPorDepartamento()
        {
            var query = from s in _context.Solicitudes
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        group s by d.Nombre into g
                        orderby g.Count() descending
                        select new
                        {
                            Departamento = g.Key,
                            TotalSolicitudes = g.Count(),
                            Pendientes = g.Count(s => s.Estado == "Pendiente"),
                            Aceptadas = g.Count(s => s.Estado == "Aceptada"),
                            Entregadas = g.Count(s => s.Estado == "Entregada"),
                            Rechazadas = g.Count(s => s.Estado == "Rechazada")
                        };

            return Ok(await query.ToListAsync());
        }

        // 3. GROUP BY + SUM — Total de items solicitados por tipo
        [HttpGet("total-items-por-tipo")]
        public async Task<IActionResult> TotalItemsPorTipo()
        {
            var query = from d in _context.DetallesSolicitud
                        join s in _context.Solicitudes on d.SolicitudId equals s.SolicitudId
                        join t in _context.TiposSolicitud on s.TipoSolicitudId equals t.TipoSolicitudId
                        group d by t.Nombre into g
                        select new
                        {
                            TipoSolicitud = g.Key,
                            TotalItems = g.Count(),
                            TotalCantidad = g.Sum(d => d.Cantidad ?? 0)
                        };

            return Ok(await query.ToListAsync());
        }

        // 4. Búsqueda por PublicId
        [HttpGet("buscar/{publicId:guid}")]
        public async Task<IActionResult> BuscarPorPublicId(Guid publicId)
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        join t in _context.TiposSolicitud on s.TipoSolicitudId equals t.TipoSolicitudId
                        where s.PublicId == publicId
                        select new
                        {
                            s.PublicId,
                            s.Estado,
                            s.Prioridad,
                            s.Observaciones,
                            s.FechaSolicitud,
                            s.FechaAceptacion,
                            s.FechaEntrega,
                            Usuario = u.Nombre,
                            Departamento = d.Nombre,
                            TipoSolicitud = t.Nombre
                        };

            var resultado = await query.FirstOrDefaultAsync();
            if (resultado == null) return NotFound();
            return Ok(resultado);
        }

        // 5. NOT EXISTS — Solicitudes sin items
        [HttpGet("solicitudes-sin-items")]
        public async Task<IActionResult> SolicitudesSinItems()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        where !_context.DetallesSolicitud.Any(det => det.SolicitudId == s.SolicitudId)
                        select new
                        {
                            s.PublicId,
                            s.Estado,
                            s.FechaSolicitud,
                            Usuario = u.Nombre,
                            Departamento = d.Nombre
                        };

            return Ok(await query.ToListAsync());
        }

        // ════════════════════════════════════════════════
        // ANALISTA (3)
        // ════════════════════════════════════════════════

        // ANALISTA 1 — Tiempos promedio de atención
        [HttpGet("tiempos-promedio-atencion")]
        public async Task<IActionResult> TiemposPromedioAtencion()
        {
            var datos = await (from s in _context.Solicitudes
                               join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                               where s.FechaAceptacion != null
                               select new
                               {
                                   Departamento = d.Nombre,
                                   s.FechaSolicitud,
                                   FechaAceptacion = s.FechaAceptacion!.Value
                               }).ToListAsync();

            var resultado = datos
                .GroupBy(s => s.Departamento)
                .Select(g => new
                {
                    Departamento = g.Key,
                    PromedioMinutos = Math.Round(g.Average(s =>
                        (s.FechaAceptacion - s.FechaSolicitud).TotalMinutes), 2)
                });

            return Ok(resultado);
        }

        // ANALISTA 2 — Solicitudes por usuario
        [HttpGet("solicitudes-por-usuario")]
        public async Task<IActionResult> SolicitudesPorUsuario()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on u.DepartamentoId equals d.DepartamentoId
                        group s by new { u.Nombre, Depto = d.Nombre } into g
                        orderby g.Count() descending
                        select new
                        {
                            Usuario = g.Key.Nombre,
                            Departamento = g.Key.Depto,
                            TotalSolicitudes = g.Count()
                        };

            return Ok(await query.ToListAsync());
        }

        // ANALISTA 3 — Historial de cambios de estado
        [HttpGet("historial-cambios-estado")]
        public async Task<IActionResult> HistorialCambiosEstado()
        {
            var query = from h in _context.HistorialSolicitudes
                        join s in _context.Solicitudes on h.SolicitudId equals s.SolicitudId
                        join u in _context.Usuarios on h.UsuarioId equals u.UsuarioId
                        orderby h.FechaCambio descending
                        select new
                        {
                            SolicitudPublicId = s.PublicId,
                            h.EstadoAnterior,
                            h.EstadoNuevo,
                            h.FechaCambio,
                            h.Observacion,
                            ResponsableCambio = u.Nombre
                        };

            return Ok(await query.ToListAsync());
        }

        // ════════════════════════════════════════════════
        // ADMINISTRADOR (3)
        // ════════════════════════════════════════════════

        // ADMINISTRADOR 1 — Solicitudes pendientes por departamento
        [HttpGet("pendientes-por-departamento")]
        public async Task<IActionResult> PendientesPorDepartamento()
        {
            var query = from s in _context.Solicitudes
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        where s.Estado == "Pendiente"
                        group s by d.Nombre into g
                        orderby g.Count() descending
                        select new
                        {
                            Departamento = g.Key,
                            SolicitudesPendientes = g.Count(),
                            Urgentes = g.Count(s => s.Prioridad == "Urgente"),
                            Criticas = g.Count(s => s.Prioridad == "Critico")
                        };

            return Ok(await query.ToListAsync());
        }

        // ADMINISTRADOR 2 — Items más solicitados
        [HttpGet("stock-disponible")]
        public async Task<IActionResult> StockDisponible()
        {
            var query = from det in _context.DetallesSolicitud
                        join s in _context.Solicitudes on det.SolicitudId equals s.SolicitudId
                        where s.Estado != "Rechazada"
                        group det by det.ItemNombre into g
                        orderby g.Sum(d => d.Cantidad ?? 0) descending
                        select new
                        {
                            Item = g.Key,
                            TotalSolicitado = g.Sum(d => d.Cantidad ?? 0),
                            VecesSolicitado = g.Count()
                        };

            return Ok(await query.ToListAsync());
        }

        // ADMINISTRADOR 3 — Solicitudes por tipo
        [HttpGet("solicitudes-por-tipo")]
        public async Task<IActionResult> SolicitudesPorTipo()
        {
            var query = from s in _context.Solicitudes
                        join t in _context.TiposSolicitud on s.TipoSolicitudId equals t.TipoSolicitudId
                        group s by new { t.Nombre, t.Categoria } into g
                        select new
                        {
                            TipoSolicitud = g.Key.Nombre,
                            Categoria = g.Key.Categoria,
                            TotalSolicitudes = g.Count(),
                            Pendientes = g.Count(s => s.Estado == "Pendiente"),
                            Completadas = g.Count(s => s.Estado == "Entregada")
                        };

            return Ok(await query.ToListAsync());
        }

        // ════════════════════════════════════════════════
        // SUPERVISOR (4)
        // ════════════════════════════════════════════════

        // SUPERVISOR 1 — Solicitudes urgentes
        [HttpGet("solicitudes-urgentes")]
        public async Task<IActionResult> SolicitudesUrgentes()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        where s.Prioridad == "Urgente" || s.Prioridad == "Critico"
                        orderby s.FechaSolicitud ascending
                        select new
                        {
                            s.PublicId,
                            s.Prioridad,
                            s.Estado,
                            s.FechaSolicitud,
                            Usuario = u.Nombre,
                            Departamento = d.Nombre
                        };

            return Ok(await query.ToListAsync());
        }

        // SUPERVISOR 2 — Completadas por día
        [HttpGet("completadas-por-dia")]
        public async Task<IActionResult> CompletadasPorDia()
        {
            var query = from s in _context.Solicitudes
                        where s.Estado == "Entregada" && s.FechaEntrega != null
                        group s by s.FechaEntrega!.Value.Date into g
                        orderby g.Key descending
                        select new
                        {
                            Fecha = g.Key,
                            Completadas = g.Count()
                        };

            return Ok(await query.ToListAsync());
        }

        // SUPERVISOR 3 — Solicitudes sin respuesta más de 24hs
        [HttpGet("solicitudes-sin-respuesta")]
        public async Task<IActionResult> SolicitudesSinRespuesta()
        {
            var limite = DateTime.UtcNow.AddHours(-24);

            var datos = await (from s in _context.Solicitudes
                               join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                               join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                               where s.Estado == "Pendiente" && s.FechaSolicitud < limite
                               orderby s.FechaSolicitud ascending
                               select new
                               {
                                   s.PublicId,
                                   s.Prioridad,
                                   s.FechaSolicitud,
                                   Usuario = u.Nombre,
                                   Departamento = d.Nombre
                               }).ToListAsync();

            var resultado = datos.Select(s => new
            {
                s.PublicId,
                s.Prioridad,
                s.FechaSolicitud,
                HorasSinRespuesta = (int)(DateTime.UtcNow - s.FechaSolicitud).TotalHours,
                s.Usuario,
                s.Departamento
            });

            return Ok(resultado);
        }

        // SUPERVISOR 4 — Reporte de rechazadas
        [HttpGet("reporte-rechazadas")]
        public async Task<IActionResult> ReporteRechazadas()
        {
            var query = from s in _context.Solicitudes
                        join u in _context.Usuarios on s.UsuarioId equals u.UsuarioId
                        join d in _context.Departamentos on s.DepartamentoId equals d.DepartamentoId
                        join h in _context.HistorialSolicitudes on s.SolicitudId equals h.SolicitudId
                        where s.Estado == "Rechazada" && h.EstadoNuevo == "Rechazada"
                        orderby s.FechaSolicitud descending
                        select new
                        {
                            s.PublicId,
                            s.FechaSolicitud,
                            MotivoRechazo = h.Observacion,
                            Usuario = u.Nombre,
                            Departamento = d.Nombre
                        };

            return Ok(await query.ToListAsync());
        }
    }
}