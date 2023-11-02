using System.ComponentModel.DataAnnotations;

namespace TheLastBugPrueba.Models
{
    public class Pais
    {
        [Key]
        public int PaisId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        public virtual ICollection<Region> Regiones { get; set; }

    }
}
