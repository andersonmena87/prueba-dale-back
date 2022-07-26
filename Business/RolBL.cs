using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Business
{
    public class RolBL : IRolBL
    {
        private readonly ApplicationDbContext _context;
        public RolBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<RolModel>> GetAll()
        {
            List<RolModel> roles = await (from rol in _context.Rol
                      select new RolModel
                      {
                          IdRol = rol.IdRol,
                          Nombre = rol.Nombre,
                      }
                      ).ToListAsync();

            return roles;
        }

        public bool Insert(RolModel rol)
        {
            _context.Add(rol);
            _context.SaveChanges();
            return true;
        }

        public bool Update(RolModel rol)
        {
            if (rol.IdRol > 0) 
            {
                _context.Update(rol);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            RolModel rol = _context.Rol.Where(r => r.IdRol == id).FirstOrDefault();

            if (rol != null)
            {
                _context.Remove(rol);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
