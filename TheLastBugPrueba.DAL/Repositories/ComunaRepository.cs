using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.DAL.Interfaces;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL.Repositories
{
    public class ComunaRepository : IComunaRepository
    {
        private readonly AppDbContext _context;

        public ComunaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comuna>> GetAllAsync()
        {
            return await _context.Comunas.ToListAsync();
        }

        public async Task<Comuna> GetByIdAsync(int id)
        {
            return await _context.Comunas.FindAsync(id);
        }

        public async Task<Comuna> AddAsync(Comuna comuna)
        {
            await _context.Comunas.AddAsync(comuna);
            await _context.SaveChangesAsync();
            return comuna;
        }

        public async Task UpdateAsync(Comuna comuna)
        {
            _context.Entry(comuna).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var comuna = await _context.Comunas.FindAsync(id);
            if (comuna != null)
            {
                _context.Comunas.Remove(comuna);
                await _context.SaveChangesAsync();
            }
        }
    }
}
