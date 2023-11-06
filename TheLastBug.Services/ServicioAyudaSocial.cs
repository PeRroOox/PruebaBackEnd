using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheLastBugPrueba.DAL;
using TheLastBugPrueba.Models;

namespace TheLastBugPrueba.Services
{
    public class ServicioAyudaSocial
    {
        private readonly AppDbContext _context;

        public ServicioAyudaSocial(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AsignarAyudaAsync(int usuarioId, int ayudaSocialId, int year)
        {
            // Verificar que la ayuda social no haya sido asignada al mismo usuario en el mismo año
            var asignacionExistente = _context.AsignacionAyudaSociales
                .Any(a => a.UsuarioId == usuarioId &&
                          a.AyudaSocialId == ayudaSocialId &&
                          a.FechaAsignacion.Year == year);
            if (asignacionExistente) return false;

            // Asignar la ayuda social
            var asignacion = new AsignacionAyudaSocial
            {
                UsuarioId = usuarioId,
                AyudaSocialId = ayudaSocialId,
                FechaAsignacion = DateTime.Now
            };
            _context.AsignacionAyudaSociales.Add(asignacion);
            await _context.SaveChangesAsync();

            return true;
        }
    }

}
