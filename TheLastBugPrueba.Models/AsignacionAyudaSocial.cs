namespace TheLastBugPrueba.Models
{
    public class AsignacionAyudaSocial
    {
        public int AsignacionAyudaSocialId { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int AyudaSocialId { get; set; }
        public virtual AyudaSocial AyudaSocial { get; set; }
        public DateTime FechaAsignacion { get; set; }
    }

}
