using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBugPrueba.DAL.Interfaces;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.DAL.Repositories
{
    public class AsignacionAyudaSocialRepository : IAsignacionAyudaSocialRepository
    {
        private readonly AppDbContext _context;

        public AsignacionAyudaSocialRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AsignacionAyudaSocial>> GetAllAsync()
        {
            return await _context.AsignacionAyudaSociales.ToListAsync();
        }

        public async Task<AsignacionAyudaSocial> GetByIdAsync(int id)
        {
            return await _context.AsignacionAyudaSociales.FindAsync(id);
        }

        public async Task<AsignacionAyudaSocial> AddAsync(AsignacionAyudaSocial ayudaSocial)
        {
            await _context.AsignacionAyudaSociales.AddAsync(ayudaSocial);
            await _context.SaveChangesAsync();
            return ayudaSocial;
        }

        public async Task UpdateAsync(AsignacionAyudaSocial ayudaSocial)
        {
            _context.Entry(ayudaSocial).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ayudaSocial = await _context.AsignacionAyudaSociales.FindAsync(id);
            if (ayudaSocial != null)
            {
                _context.AsignacionAyudaSociales.Remove(ayudaSocial);
                await _context.SaveChangesAsync();
            }
        }
    }
}
