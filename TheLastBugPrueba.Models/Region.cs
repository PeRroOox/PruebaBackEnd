namespace TheLastBugPrueba.Models
{
    public class Region
    {
        public int RegionId { get; set; }
        public string Nombre { get; set; }
        public int PaisId { get; set; }
        public virtual Pais Pais { get; set; }
        public virtual ICollection<Comuna> Comunas { get; set; }
    }

}
