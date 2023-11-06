namespace TheLastBugPrueba.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public virtual ICollection<AyudaSocial> AyudasSociales { get; set; }
        public virtual ICollection<AsignacionAyudaSocial> AsignacionesAyudaSocial { get; set; }
    }
}
