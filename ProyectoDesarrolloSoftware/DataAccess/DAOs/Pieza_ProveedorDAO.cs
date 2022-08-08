using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class Pieza_ProveedorDAO : IPieza_ProveedorDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);

        /*public readonly DSDBContext _context;

        public object objeto { get; private set; }

        public Pieza_ProveedorDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public Task Add(Pieza_ProveedorDTO pieza_proveedorDTO)
        {
            Pieza_Proveedor pieza_proveedor = new Pieza_Proveedor();
            pieza_proveedor.Id_Pieza = pieza_proveedorDTO.Id_Pieza;
            pieza_proveedor.Id_proveedor = pieza_proveedorDTO.Id_Proveedor;
            pieza_proveedor.cantidad = pieza_proveedorDTO.cantidad;
            _context.Pieza_Proveedor.Add(pieza_proveedor);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }


        public List<Pieza_ProveedorDTO> GetListaPiezasDeProveedoresById(int Id_Proveedor)
        {
            try
            {
                var query = (from pp in _context.Pieza_Proveedor
                             from pi in _context.Piezas
                             from pr in _context.Proveedores
                             where pr.Id_proveedor == Id_Proveedor      
                             && pp.Id_proveedor == pr.Id_proveedor
                             && pp.Id_Pieza == pi.Id_Pieza
                             select new Pieza_ProveedorDTO
                             {
                                 Id_Pieza = pi.Id_Pieza,
                                 Id_Proveedor = pr.Id_proveedor,
                                 cantidad = pp.cantidad,
                                 Nombre_Proveedor = pr.Nombre,
                                 Nombre_Pieza = pi.Nombre
                             }).ToList();

                return query;                
            }
            catch (Exception)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }

        public Pieza_ProveedorDTO GetPiezaDeProveedor(int Id_Pieza, int Id_Proveedor)
        {
            
            var query = (from pp in _context.Pieza_Proveedor
                         join pi in _context.Piezas on pp.Id_Pieza equals pi.Id_Pieza
                         join pr in _context.Proveedores on pp.Id_proveedor equals pr.Id_proveedor
                         where pi.Id_Pieza == pp.Id_Pieza
                         && pr.Id_proveedor == pp.Id_proveedor
                         select new Pieza_ProveedorDTO
                         {
                             Id_Pieza = pi.Id_Pieza,
                             Id_Proveedor = pr.Id_proveedor,
                             cantidad = pp.cantidad,
                             Nombre_Proveedor = pr.Nombre,
                             Nombre_Pieza = pi.Nombre
                         });

            return query.First();
        }

        public Task delete(int Id_Pieza, int Id_Proveedor)
        {
            var ItemToRemove = _context.Pieza_Proveedor.Find(Id_Pieza, Id_Proveedor);
            _context.Pieza_Proveedor.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(Pieza_ProveedorDTO pieza_proveedorDTO, int Id_Pieza, int Id_proveedor)
        {
            var itemToUpdate = _context.Pieza_Proveedor.Find(Id_Pieza, Id_proveedor);
            itemToUpdate.cantidad = pieza_proveedorDTO.cantidad;
            _context.DbContext.SaveChanges();


            return Task.CompletedTask;
        }

       
    }
}
