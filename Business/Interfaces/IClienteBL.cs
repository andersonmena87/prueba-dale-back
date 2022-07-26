using ApiPruebaTecnica.Models;

namespace ApiPruebaTecnica.Business.Interfaces
{
    public interface IClienteBL
    {
        public Task<List<ClienteModel>> GetAll();

        public bool Insert(ClienteModel cliente);

        public bool Update(ClienteModel cliente);

        public bool Delete(int id);
    }
}
