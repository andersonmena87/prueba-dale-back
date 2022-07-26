using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Business
{
    public class ClienteBL : IClienteBL
    {
        private readonly ApplicationDbContext _context;
        public ClienteBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClienteModel>> GetAll()
        {
            List<ClienteModel> clientes = await (from cliente in _context.Cliente
                      select new ClienteModel
                      {
                          IdCliente = cliente.IdCliente,
                          Nombre = cliente.Nombre,
                          Apellido = cliente.Apellido,
                          Cedula = cliente.Cedula,
                          Telefono = cliente.Telefono
                      }
                      ).ToListAsync();

            return clientes;
        }

        public bool Insert(ClienteModel cliente)
        {
            _context.Add(cliente);
            _context.SaveChanges();
            return true;
        }

        public bool Update(ClienteModel cliente)
        {
            if (cliente.IdCliente > 0) 
            {
                _context.Update(cliente);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            ClienteModel cliente = _context.Cliente.Where(c => c.IdCliente == id).FirstOrDefault();

            if (cliente != null)
            {
                _context.Remove(cliente);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
