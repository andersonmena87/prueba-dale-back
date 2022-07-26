using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Entities
{
    [Table("detalleventa")]
    public class DetalleVentaEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("iddetalleventa")]
        public int IdDetalleVenta { get; set; }

        [Column("idventa")]
        public int IdVenta { get; set; }

        [Column("idproducto")]
        public int IdProducto { get; set; }

        [Column("cantidad")]
        public int Cantidad { get; set; }

        [Column("total")]
        public int Total { get; set; }
    }
}
