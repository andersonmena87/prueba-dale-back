using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebaTecnica.Entities
{
    [Table("rol")]
    public class RolEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idrol")]
        public int IdRol { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
