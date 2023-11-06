namespace TheLastBugPrueba.Models
{
    public class Comuna
    {
        public int ComunaId { get; set; }
        public string Nombre { get; set; }
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<AyudaSocial> AyudasSociales { get; set; }

    }
}
