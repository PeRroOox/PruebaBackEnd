using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.Models;
using TheLastBugPrueba.DAL;

namespace TheLastBugPrueba.Api.Controllers
{
    [Authorize(Roles = "Administrador")]
    [ApiController]
    [Route("api/[controller]")]
    public class ComunasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ComunasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Comunas
        [HttpGet]
        [AllowAnonymous] // Permite el acceso a todos los usuarios
        public async Task<ActionResult<IEnumerable<Comuna>>> GetComunas()
        {
            return await _context.Comunas.Include(c => c.Region).ToListAsync();
        }

        // GET: api/Comunas/5
        [HttpGet("{id}")]
        [AllowAnonymous] // Permite el acceso a todos los usuarios
        public async Task<ActionResult<Comuna>> GetComuna(int id)
        {
            var comuna = await _context.Comunas.Include(c => c.Region).SingleOrDefaultAsync(c => c.ComunaId == id);

            if (comuna == null)
            {
                return NotFound();
            }

            return comuna;
        }

        // POST: api/Comunas
        [HttpPost]
        public async Task<ActionResult<Comuna>> PostComuna(Comuna comuna)
        {
            _context.Comunas.Add(comuna);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComuna", new { id = comuna.ComunaId }, comuna);
        }

        // PUT: api/Comunas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComuna(int id, Comuna comuna)
        {
            if (id != comuna.ComunaId)
            {
                return BadRequest();
            }

            _context.Entry(comuna).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComunaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Comunas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComuna(int id)
        {
            var comuna = await _context.Comunas.FindAsync(id);
            if (comuna == null)
            {
                return NotFound();
            }

            _context.Comunas.Remove(comuna);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ComunaExists(int id)
        {
            return _context.Comunas.Any(e => e.ComunaId == id);
        }
    }
}
