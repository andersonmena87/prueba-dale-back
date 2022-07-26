using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class ClienteModel
    {
        [Key]
        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Cedula { get; set; }

        public string Telefono { get; set; }
    }
}
