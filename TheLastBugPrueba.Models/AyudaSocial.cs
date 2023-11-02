using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheLastBugPrueba.Models
{
    public class AyudaSocial
    {
        [Key]
        public int AyudaSocialId { get; set; }

        [Required]
        [StringLength(200)]
        public string Descripcion { get; set; }

        [ForeignKey("Comuna")]
        public int ComunaId { get; set; }

        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        public virtual Comuna Comuna { get; set; }
        public virtual Usuario Usuario { get; set; }


    }
}
