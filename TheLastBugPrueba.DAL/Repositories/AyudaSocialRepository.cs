using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.DAL.Interfaces;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL.Repositories
{
    public class AyudaSocialRepository : IAyudaSocialRepository
    {
        private readonly AppDbContext _context;

        public AyudaSocialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AyudaSocial>> GetAllAsync()
        {
            return await _context.AyudasSociales.ToListAsync();
        }

        public async Task<AyudaSocial> GetByIdAsync(int id)
        {
            return await _context.AyudasSociales.FindAsync(id);
        }

        public async Task<AyudaSocial> AddAsync(AyudaSocial ayudaSocial)
        {
            await _context.AyudasSociales.AddAsync(ayudaSocial);
            await _context.SaveChangesAsync();
            return ayudaSocial;
        }

        public async Task UpdateAsync(AyudaSocial ayudaSocial)
        {
            _context.Entry(ayudaSocial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ayudaSocial = await _context.AyudasSociales.FindAsync(id);
            if (ayudaSocial != null)
            {
                _context.AyudasSociales.Remove(ayudaSocial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
