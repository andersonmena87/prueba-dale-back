using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IRolBL
    {
        public Task<List<RolModel>> GetAll();

        public bool Insert(RolModel rol);

        public bool Update(RolModel rol);

        public bool Delete(int id);
    }
}
