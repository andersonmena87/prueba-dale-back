using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class RolModel
    {
        [Key]
        public int IdRol { get; set; }

        public string Nombre { get; set; }
    }
}
