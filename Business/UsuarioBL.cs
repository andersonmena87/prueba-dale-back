using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiPruebaTecnica.Business
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly ApplicationDbContext _context;
        public UsuarioBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            List<UsuarioModel> usuarios = await (from usuario in _context.Usuario
                                                 join rol in _context.Rol on usuario.IdRol equals rol.IdRol 
                      select new UsuarioModel 
                      {
                          IdUsuario = usuario.IdUsuario,
                          Nombre = usuario.Nombre,
                          Cedula = usuario.Cedula,
                          Telefono = usuario.Telefono,
                          Username = usuario.Username,
                          Password = usuario.Password,
                          IdRol = usuario.IdRol,
                          Rol = rol
                      }
                      ).ToListAsync();

            return usuarios;
        }

        public bool Insert(UsuarioModel usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
            return true;
        }

        public bool Update(UsuarioModel usuario)
        {
            if (usuario.IdUsuario > 0) 
            {
                _context.Update(usuario);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            UsuarioModel usuario = _context.Usuario.Where(u => u.IdUsuario == id).FirstOrDefault();

            if (usuario != null)
            {
                _context.Remove(usuario);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
