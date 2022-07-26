using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Business
{
    public class ProductoBL : IProductoBL
    {
        private readonly ApplicationDbContext _context;
        public ProductoBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoModel>> GetAll()
        {
            List<ProductoModel> productos = await (from producto in _context.Producto
                      select new ProductoModel
                      {
                          IdProducto = producto.IdProducto,
                          Nombre = producto.Nombre,
                          ValorUnitario = producto.ValorUnitario,
                      }
                      ).ToListAsync();

            return productos;
        }

        public bool Insert(ProductoModel producto)
        {
            _context.Add(producto);
            _context.SaveChanges();
            return true;
        }

        public bool Update(ProductoModel producto)
        {
            if (producto.IdProducto > 0) 
            {
                _context.Update(producto);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            ProductoModel producto = _context.Producto.Where(p => p.IdProducto == id).FirstOrDefault();

            if (producto != null)
            {
                _context.Remove(producto);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
