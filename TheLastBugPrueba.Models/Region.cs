using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheLastBugPrueba.Models
{
    public class Region
    {
        [Key]
        public int RegionId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [ForeignKey("Pais")]
        public int PaisId { get; set; }

        public virtual Pais Pais { get; set; }
        public virtual ICollection<Comuna> Comunas { get; set; }


    }

}
