namespace TheLastBugPrueba.Models
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public virtual ICollection<Region> Regiones { get; set; }
    }
}
