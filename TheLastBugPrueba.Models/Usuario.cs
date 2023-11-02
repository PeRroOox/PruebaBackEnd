using System.ComponentModel.DataAnnotations;

namespace TheLastBugPrueba.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }

        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string Telefono { get; set; }
        

    }
}
