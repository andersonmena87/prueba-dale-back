﻿using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using ApiPruebaTecnica.DTO;
using ApiPruebaTecnica.Entities;
using ApiPruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiPruebaTecnica.Business
{
    public class VentaBL : IVentaBL
    {
        private readonly ApplicationDbContext _context;
        public VentaBL(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VentaDto>> GetAll()
        {
            List<VentaDto> ventas = await (from venta in _context.Venta
                                             join detalleVenta in _context.DetalleVenta on venta.IdVenta equals detalleVenta.IdVenta
                                             join cliente in _context.Cliente on venta.IdCliente equals cliente.IdCliente
                                             join usuario in _context.Usuario on venta.IdUsuario equals usuario.IdUsuario
                                             join rol in _context.Rol on usuario.IdUsuario equals rol.IdRol
                                             join producto in _context.Producto on detalleVenta.IdProducto equals producto.IdProducto
                                             select new VentaDto
                                             {
                          IdVenta = venta.IdVenta,
                          IdCliente = venta.IdCliente,
                          IdUsuario = venta.IdUsuario,
                          Usuario = usuario,
                          Producto = producto,
                          Cliente = cliente,
                          DetalleVenta = detalleVenta
                      }
                      ).ToListAsync();

            return ventas;
        }

        public bool Insert(VentaDto _venta)
        {
            VentaModel venta = new VentaModel
            {
                IdCliente = _venta.IdCliente,
                IdUsuario = _venta.IdUsuario
            };


            EntityEntry<VentaModel> entityEntry = _context.Add(venta);
            _context.SaveChanges();

            venta.IdVenta = entityEntry.Entity.IdVenta;

            DetalleVentaModel detalleVenta = new DetalleVentaModel
            {
                IdVenta = venta.IdVenta,
                IdProducto = _venta.DetalleVenta.IdProducto,
                Cantidad = _venta.DetalleVenta.Cantidad,
                Total = _venta.DetalleVenta.Total
            };

            _context.Add(detalleVenta);
            _context.SaveChanges();

            return true;
        }

        public bool Update(VentaModel venta)
        {
            if (venta.IdVenta > 0) 
            {
                _context.Update(venta);
                _context.SaveChanges();
                return true;
            }
            
            return false;
        }

        public bool Delete(int id)
        {
            VentaModel venta = _context.Venta.Where(p => p.IdVenta == id).FirstOrDefault();

            if (venta != null)
            {
                _context.Remove(venta);
                _context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
