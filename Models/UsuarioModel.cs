using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class UsuarioModel
    {
        [Key]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public int IdRol { get; set; }

        public virtual RolModel Rol { get; set; }
    }
}
