using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.Models
{
    public class VentaModel
    {
        [Key]
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public virtual ClienteModel Cliente { get; set; }

        public virtual UsuarioModel Usuario { get; set; }

        public virtual DetalleVentaModel DetalleVenta { get; set; }
    }
}
