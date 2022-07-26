using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IProductoBL
    {
        public Task<List<ProductoModel>> GetAll();

        public bool Insert(ProductoModel producto);

        public bool Update(ProductoModel producto);

        public bool Delete(int id);
    }
}
