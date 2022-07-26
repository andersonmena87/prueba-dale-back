using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IVentaBL
    {
        public Task<List<VentaModel>> GetAll();

        public bool Insert(VentaModel venta);

        public bool Update(VentaModel venta);

        public bool Delete(int id);
    }
}
