using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Models
{
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdUsuario { get; set; }
        public string UserUsuario { get; set; }
        public string PassUsuario { get; set; }
        public int StatusUsuario { get; set; }
        public int TipoUsuario { get; set; }

    }
}