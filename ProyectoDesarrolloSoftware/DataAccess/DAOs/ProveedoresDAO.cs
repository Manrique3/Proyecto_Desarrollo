﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class ProveedoresDAO : IProveedoresDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);

        /*public readonly DSDBContext _context;

        public ProveedoresDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public Task Add(ProveedorDTO proveedorDTO)
        {
            Proveedor proveedor = new Proveedor();
            proveedor.Id_proveedor = proveedorDTO.Id_Proveedor;
            proveedor.Nombre = proveedorDTO.Nombre;
            proveedor.Lugar = proveedorDTO.Lugar;
            _context.Proveedores.Add(proveedor);
            _context.DbContext.SaveChanges();
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
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(ProveedorDTO proveedorDTO, int Id_Proveedor)
        {
            var itemToUpdate = _context.Proveedores.Find(Id_Proveedor);
            if (proveedorDTO.Nombre.Length > 0 && proveedorDTO.Nombre != "string")
            {
                itemToUpdate.Nombre = proveedorDTO.Nombre;
            }

            if (proveedorDTO.Lugar.Length > 0 && proveedorDTO.Lugar != "string")
            {
               itemToUpdate.Lugar = proveedorDTO.Lugar;

            }
            _context.DbContext.SaveChanges();


            return Task.CompletedTask;
        }

    
    }
}
