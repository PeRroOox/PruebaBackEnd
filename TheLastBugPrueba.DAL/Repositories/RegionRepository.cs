using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.DAL.Interfaces;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly AppDbContext _context;

        public RegionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await _context.Regiones.ToListAsync();
        }

        public async Task<Region> GetByIdAsync(int id)
        {
            return await _context.Regiones.FirstOrDefaultAsync(r => r.RegionId == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            await _context.Regiones.AddAsync(region);
            await _context.SaveChangesAsync();
            return region;
        }

        public async Task UpdateAsync(Region region)
        {
            _context.Entry(region).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var region = await _context.Regiones.FindAsync(id);
            if (region != null)
            {
                _context.Regiones.Remove(region);
                await _context.SaveChangesAsync();
            }
        }
    }
}
