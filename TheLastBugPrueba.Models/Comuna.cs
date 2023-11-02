using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheLastBugPrueba.Models
{
    public class Comuna
    {
        [Key]
        public int ComunaId { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [ForeignKey("Region")]
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<AyudaSocial> AyudasSociales { get; set; }


    }
}
