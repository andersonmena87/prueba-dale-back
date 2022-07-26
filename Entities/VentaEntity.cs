using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Entities
{
    [Table("venta")]
    public class VentaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idventa")]
        public int IdVenta { get; set; }

        [Column("idcliente")]
        public int IdCliente { get; set; }

        [Column("idusuario")]
        public int IdUsuario { get; set; }

    }
}
