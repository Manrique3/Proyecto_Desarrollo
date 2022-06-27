using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public class ProveedoresDAO : IProveedoresDAO
    {
        public readonly DSDBContext _context;

        public ProveedoresDAO(DSDBContext context)
        {
            _context = context;
        }

        public Task Add(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Id_proveedor = proveedorDTO.Id_Proveedor;
            proveedor.Nombre = proveedorDTO.Nombre;
            proveedor.Lugar = proveedorDTO.Lugar;
            _context.Proveedores.Add(proveedor);
            _context.SaveChanges();
            return Task.CompletedTask;
        }


        public List<ProveedorDTO> GetListaProveedoresByName(string Nombre)
        {
            try
            {
                var query = _context.Proveedores
                   .Where(b => b.Nombre == Nombre)
                   .Select(b => new ProveedorDTO
                   {
                       Id_Proveedor = b.Id_proveedor,
                       Nombre = b.Nombre,
                       Lugar = b.Lugar
                   }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }

        public ProveedorDTO GetProveedor(int Id_Proveedor)
        {
            var query = _context.Proveedores
                  .Where(b => b.Id_proveedor == Id_Proveedor)
                  .Select(b => new ProveedorDTO
                  {
                      Id_Proveedor = b.Id_proveedor,
                      Nombre = b.Nombre,
                      Lugar = b.Lugar
                  });

            return query.First();
        }

        public Task delete(int Id_Proveedor)
        {
            var ItemToRemove = _context.Proveedores.Find(Id_Proveedor);
            _context.Proveedores.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(ProveedorDTO proveedorDTO, int Id_Proveedor)
        {
            var itemToUpdate = _context.Proveedores.Find(Id_Proveedor);
            if (proveedorDTO.Nombre.Length > 0)
            {
                itemToUpdate.Nombre = proveedorDTO.Nombre;
            }

            if (proveedorDTO.Lugar.Length > 0)
            {
               itemToUpdate.Lugar = proveedorDTO.Lugar;

            }
            _context.SaveChanges();


            return Task.CompletedTask;
        }
    }
}
