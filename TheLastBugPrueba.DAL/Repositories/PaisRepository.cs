using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.DAL.Interfaces;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL.Repositories
{
    public class PaisRepository : IPaisRepository
    {
        private readonly AppDbContext _context;

        public PaisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Pais>> GetAllAsync()
        {
            return await _context.Paises.ToListAsync();
        }

        public async Task<Pais> GetByIdAsync(int id)
        {
            return await _context.Paises.FindAsync(id);
        }

        public async Task<Pais> AddAsync(Pais pais)
        {
            await _context.Paises.AddAsync(pais);
            await _context.SaveChangesAsync();
            return pais;
        }

        public async Task UpdateAsync(Pais pais)
        {
            _context.Paises.Update(pais);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais != null)
            {
                _context.Paises.Remove(pais);
                await _context.SaveChangesAsync();
            }
        }
    }
}
