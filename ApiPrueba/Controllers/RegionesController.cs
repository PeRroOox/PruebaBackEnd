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
    public class RegionesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RegionesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Regiones
        [HttpGet]
        [AllowAnonymous] // Permite el acceso a todos los usuarios
        public async Task<ActionResult<IEnumerable<Region>>> GetRegiones()
        {
            return await _context.Regiones.ToListAsync();
        }

        // GET: api/Regiones/5
        [HttpGet("{id}")]
        [AllowAnonymous] // Permite el acceso a todos los usuarios
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region = await _context.Regiones.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return region;
        }

        // POST: api/Regiones
        [HttpPost]
        public async Task<ActionResult<Region>> PostRegion(Region region)
        {
            _context.Regiones.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.RegionId }, region);
        }

        // PUT: api/Regiones/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegion(int id, Region region)
        {
            if (id != region.RegionId)
            {
                return BadRequest();
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
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

        // DELETE: api/Regiones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = await _context.Regiones.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regiones.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return _context.Regiones.Any(e => e.RegionId == id);
        }
    }
}
