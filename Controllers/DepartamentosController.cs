using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticaHospitalaria_Backend.Models;
using LogisticaHospitalaria_Backend.Data;

[Route("api/[controller]")]
[ApiController]
public class DepartamentosController : ControllerBase
{
    private readonly LogisticaHospitalariaContext _context;

    public DepartamentosController(LogisticaHospitalariaContext context)
    {
        _context = context;
    }

    // GET: api/Departamentos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamentos()
    {
        return await _context.Departamentos
            .Where(d => d.Activo)
            .OrderBy(d => d.Nombre)
            .ToListAsync();
    }

    // GET: api/Departamentos/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Departamento>> GetDepartamento(int id)
    {
        var departamento = await _context.Departamentos.FindAsync(id);
        if (departamento == null) return NotFound();
        return departamento;
    }
}