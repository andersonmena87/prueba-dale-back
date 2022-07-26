using ApiPruebaTecnica.DTO;
using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IVentaBL
    {
        public Task<List<VentaDto>> GetAll();

        public bool Insert(VentaDto venta);

        public bool Update(VentaModel venta);

        public bool Delete(int id);
    }
}
