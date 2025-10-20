using System.ComponentModel.DataAnnotations;

namespace Autonomus.Entities
{
    public class Login
    {
        [Key]
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public int IdUsuario { get; set; }
    }
}
