using ApiPruebaTecnica.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiPruebaTecnica.DTO
{
    public class VentaDto
    {
        [Key]
        public int IdVenta { get; set; }

        public int IdCliente { get; set; }

        public int IdUsuario { get; set; }

        public virtual ClienteModel Cliente { get; set; }

        public virtual UsuarioModel Usuario { get; set; }

        public virtual DetalleVentaModel DetalleVenta { get; set; }

        public virtual ProductoModel Producto { get; set; }
    }
}
