using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class ProductoModel
    {
        [Key]
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public int ValorUnitario { get; set; }
    }
}