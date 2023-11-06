namespace TheLastBugPrueba.Models
{
    public class AyudaSocial
    {
        public int AyudaSocialId { get; set; }
        public string Descripcion { get; set; }
        public int ComunaId { get; set; }
        public int UsuarioId { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual Usuario Usuario { get; set; }
        public virtual ICollection<AsignacionAyudaSocial> AsignacionesAyudaSocial { get; set; }
    }
}
