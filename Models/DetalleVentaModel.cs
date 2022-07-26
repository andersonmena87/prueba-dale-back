using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class DetalleVentaModel
    {
        [Key]
        public int IdDetalleVenta { get; set; }

        public int IdVenta { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }

        public virtual ProductoModel Producto { get; set; }
    }
}
