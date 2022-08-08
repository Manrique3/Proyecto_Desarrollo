using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class Cotizacion_TallerDAO : ICotizacion_TallerDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);

        /*public readonly DSDBContext _context;

        public Cotizacion_TallerDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public List<Cotizacion_TallerDTO> GetListaCotizacionDeTallerById(int Id_Cotizacion)
        {
            try
            {
                var data = _context.Cotizacion_Taller
                   .Where(a => a.Id_Cotizacion == Id_Cotizacion)
                   .Select(a => new Cotizacion_TallerDTO
                   {
                       Id_Cotizacion = a.Id_Cotizacion,
                       Id_Taller = a.Id_Taller,
                       estatus = a.estatus,
                       cantidad_piezas_reparar = a.cantidad_piezas_reparar,
                       costo_reparacion = a.costo_reparacion,
                       tiempo_reparacion = a.tiempo_reparacion
                   }).ToList();

                return data;
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de Cotizaciones de talleres" + Id_Cotizacion, ex.Message, ex);
            }

        }

        public Task Add(Cotizacion_TallerDTO cotizacion_TallerDTO, int Id_Cotizacion)
        {
            int id_del_taller;
            id_del_taller = (from ta in _context.Taller_Marcas
                         from ma in _context.Marcas
                         from co in _context.Cotizacions
                         from inc in _context.Incidentes
                         from ve in _context.Vehiculos
                         from po in _context.Polizas
                         from ct in _context.Cotizacion_Taller

                         where co.Id_Cotizacion == Id_Cotizacion                         
                         && co.fk_incidente == inc.Id_Incidente
                         && inc.fk_Poliza == po.Id_Poliza
                         && po.fk_vehiculo == ve.Placa
                         && ve.fk_marca == ma.IDMarca
                         && ma.IDMarca == ta.IDMarca

                         select ta.Id_Taller                        
                         ).First();          
            
            

            Cotizacion_Taller cotizacion_taller = new Cotizacion_Taller();
            cotizacion_TallerDTO.Id_Cotizacion = Id_Cotizacion;
            cotizacion_TallerDTO.Id_Taller = id_del_taller;
            cotizacion_taller.Id_Cotizacion = cotizacion_TallerDTO.Id_Cotizacion;
            cotizacion_taller.Id_Taller = cotizacion_TallerDTO.Id_Taller;
            cotizacion_taller.costo_reparacion = cotizacion_TallerDTO.costo_reparacion;
            cotizacion_taller.tiempo_reparacion = cotizacion_TallerDTO.tiempo_reparacion;
            cotizacion_taller.cantidad_piezas_reparar = cotizacion_TallerDTO.cantidad_piezas_reparar;
            cotizacion_taller.estatus = cotizacion_TallerDTO.estatus;

            _context.Cotizacion_Taller.Add(cotizacion_taller);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(Cotizacion_TallerDTO cotizacion_TallerDTO, int Id_Cotizacion)
        {
            var itemToUpdate = _context.Cotizacion_Taller.Find(Id_Cotizacion);
            itemToUpdate.tiempo_reparacion = cotizacion_TallerDTO.tiempo_reparacion;
            itemToUpdate.costo_reparacion = cotizacion_TallerDTO.costo_reparacion;
            itemToUpdate.cantidad_piezas_reparar = cotizacion_TallerDTO.cantidad_piezas_reparar;
            _context.DbContext.SaveChanges();

            return Task.CompletedTask;
        }


        public Task delete(int Id_Cotizacion)
        {
            var ItemToRemove = _context.Cotizacion_Taller.Find(Id_Cotizacion);
            _context.Cotizacion_Taller.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Cotizacion_TallerDTO GetCotizacionTaller(int Id_Cotizacion)
        {
            var query = _context.Cotizacion_Taller
                .Where(a => a.Id_Cotizacion == Id_Cotizacion)
                .Select(a => new Cotizacion_TallerDTO
                {
                    Id_Cotizacion = a.Id_Cotizacion,
                    cantidad_piezas_reparar = a.cantidad_piezas_reparar,
                    tiempo_reparacion = a.tiempo_reparacion,
                    Id_Taller = a.Id_Taller,
                    costo_reparacion = a.costo_reparacion,
                    estatus = a.estatus
                });
            return query.First();
        }        
       
    }
}
