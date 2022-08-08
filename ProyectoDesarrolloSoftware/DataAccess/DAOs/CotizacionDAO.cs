using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class CotizacionDAO : ICotizacionDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);

        /*public readonly DSDBContext _context;

        public CotizacionDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public List<CotizacionDTO> GetListaCotizacionesById(int Id_Cotizacion)
        {
            try
            {
                var data = _context.Cotizacions
                   .Where(a => a.Id_Cotizacion == Id_Cotizacion)
                   .Select(a => new CotizacionDTO
                   {
                       Id_cotizacion = a.Id_Cotizacion,
                       fk_incidente = a.fk_incidente                       
                   });

                return data.ToList();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de Cotizaciones" + Id_Cotizacion, ex.Message, ex);
            }

        }

        public Task Add(CotizacionDTO cotizacionDTO)
        {
            Cotizacion cotizacion = new Cotizacion();
            cotizacion.Id_Cotizacion = cotizacionDTO.Id_cotizacion;
            cotizacion.fk_incidente = cotizacionDTO.fk_incidente;
            _context.Cotizacions.Add(cotizacion);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task Update(CotizacionDTO cotizacionDTO, int Id_Cotizacion)
        {
            var itemToUpdate = _context.Cotizacions.Find(Id_Cotizacion);
            itemToUpdate.fk_incidente = cotizacionDTO.fk_incidente;
            _context.DbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(int Id_Cotizacion)
        {
            var ItemToRemove = _context.Cotizacions.Find(Id_Cotizacion);
            _context.Cotizacions.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public CotizacionDTO GetCotizacion(int Id_Cotizacion)
        {
            var query = _context.Cotizacions
                .Where(a => a.Id_Cotizacion == Id_Cotizacion)
                .Select(a => new CotizacionDTO
                {
                    Id_cotizacion = a.Id_Cotizacion,
                    fk_incidente = a.fk_incidente
                });
            return query.First();
        }

       
    }
}
