using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public class Cotizacion_ProveedorDAO : ICotizacion_ProveedorDAO
    {
        public DSDBContext _context;

        public Cotizacion_ProveedorDAO(DSDBContext context)
        {
            _context = context;

        }
        public Task AddCotizacion_Proveedor(Cotizacion_proveedorDTO cotizacion_proveedorDTO, int Id_Cotizacion)
        {
            int id_del_proveedor;

            id_del_proveedor = (from pm in _context.ProvMarcas
                                from cp in _context.Cotizacion_Proveedor
                                from c in _context.Cotizacions
                                from i in _context.Incidentes
                                from p in _context.Polizas
                                from v in _context.Vehiculos
                                from m in _context.Marcas


                                where c.Id_Cotizacion == Id_Cotizacion
                                && c.fk_incidente == i.Id_Incidente
                                && i.fk_Poliza == p.Id_Poliza
                                && p.fk_vehiculo == v.Placa
                                && v.fk_marca == m.IDMarca
                                && m.IDMarca == pm.IDMarca

                                select pm.Id_proveedor
                                ).First();

            /*Cotizacion_Taller cotizacion_taller = new Cotizacion_Taller();
            cotizacion_TallerDTO.Id_Cotizacion = Id_Cotizacion;
            cotizacion_TallerDTO.Id_Taller = id_del_taller;
            cotizacion_taller.Id_Cotizacion = cotizacion_TallerDTO.Id_Cotizacion;
            cotizacion_taller.Id_Taller = cotizacion_TallerDTO.Id_Taller;
            cotizacion_taller.costo_reparacion = cotizacion_TallerDTO.costo_reparacion;
            cotizacion_taller.tiempo_reparacion = cotizacion_TallerDTO.tiempo_reparacion;
            cotizacion_taller.cantidad_piezas_reparar = cotizacion_TallerDTO.cantidad_piezas_reparar;
            cotizacion_taller.estatus = cotizacion_TallerDTO.estatus;*/


            Cotizacion_Proveedor cotizacion_pro = new Cotizacion_Proveedor();
            cotizacion_proveedorDTO.Id_Cotizacion = Id_Cotizacion;
            cotizacion_proveedorDTO.Id_Proveedor = id_del_proveedor;
            cotizacion_pro.Id_Cotizacion = cotizacion_proveedorDTO.Id_Cotizacion;
            cotizacion_pro.Id_Proveedor = cotizacion_proveedorDTO.Id_Proveedor;
            cotizacion_pro.estatus = cotizacion_proveedorDTO.estatus;
            cotizacion_pro.Id_Proveedor_Pieza_Proveedor = cotizacion_proveedorDTO.Id_Proveedor;
            
            _context.Cotizacion_Proveedor.Add(cotizacion_pro);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task DeleteCotizacion_Proveedor(int Id_Cotizacion, int Id_Proveedor)
        {
            
                var ItemToRemove = _context.Cotizacion_Proveedor.Find(Id_Cotizacion, Id_Proveedor);
                _context.Cotizacion_Proveedor.Remove(ItemToRemove);
                _context.SaveChanges();
                return Task.CompletedTask;
            
        }

        public Task EditCotizacion_Proveedor(Cotizacion_proveedorDTO cotizacion_proveedorDTO, int Id_Cotizacion, int Id_Proveedor)
        {
            var itemToUpdate = _context.Cotizacion_Proveedor.Find(Id_Cotizacion, Id_Proveedor);
            itemToUpdate.estatus = cotizacion_proveedorDTO.estatus;
             _context.SaveChanges();
            return Task.CompletedTask;
        }

        public List<Cotizacion_proveedorDTO> GetCotizacionesPorProveedor(int Id_Proveedor)
        {
            try
            {
                var query = (from CP in _context.Cotizacion_Proveedor //Query para buscar el taller con sus marcas
                             join C in _context.Cotizacions on CP.Id_Cotizacion equals C.Id_Cotizacion
                             join P in _context.Proveedores on CP.Id_Proveedor equals P.Id_proveedor
                             join PP in _context.Pieza_Proveedor on CP.Id_Pieza_Pieza_Proveedor equals PP.Id_Pieza
                             join Pi in _context.Piezas on PP.Id_Pieza equals Pi.Id_Pieza
                             where CP.Id_Proveedor == Id_Proveedor
                           
                             select new Cotizacion_proveedorDTO
                             {
                                 Id_Cotizacion = C.Id_Cotizacion,
                                 Id_Proveedor = P.Id_proveedor,
                                 estatus = CP.estatus,

                                 Nombre_Proveedor = P.Nombre,
                                 Nombre_Pieza = Pi.Nombre

                             }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }

        public List<Cotizacion_proveedorDTO> GetProveedoresPorCotizaciones(int Id_Cotizacion)
        {
            try
            {
                var query = (from CP in _context.Cotizacion_Proveedor 
                             join C in _context.Cotizacions on CP.Id_Cotizacion equals C.Id_Cotizacion
                             join P in _context.Proveedores on CP.Id_Proveedor equals P.Id_proveedor
                             join PP in _context.Pieza_Proveedor on CP.Id_Pieza_Pieza_Proveedor equals PP.Id_Pieza
                             join Pi in _context.Piezas on PP.Id_Pieza equals Pi.Id_Pieza
                             where CP.Id_Cotizacion == Id_Cotizacion

                             select new Cotizacion_proveedorDTO
                             {
                                 Id_Cotizacion = C.Id_Cotizacion,
                                 Id_Proveedor = P.Id_proveedor,
                                 estatus = CP.estatus,

                                 Nombre_Proveedor = P.Nombre,
                                 Nombre_Pieza = Pi.Nombre

                             }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }
    }
}
