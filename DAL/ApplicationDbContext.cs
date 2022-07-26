using ApiPruebaTecnica.Entities;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.DB
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<RolModel> Rol { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<ProductoModel> Producto { get; set; }
        public DbSet<VentaModel> Venta { get; set; }
        public DbSet<DetalleVentaModel> DetalleVenta { get; set; }

    }
}
