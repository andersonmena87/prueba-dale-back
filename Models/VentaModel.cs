using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class VentaModel
    {
        [Key]
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }
    }
}
