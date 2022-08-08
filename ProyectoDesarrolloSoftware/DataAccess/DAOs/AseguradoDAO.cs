using System;
using System.Collections.Generic;
using System.Linq;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.Fabricas;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class AseguradoDAO : IAseguradoDAO
    {

        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);

        /*public readonly DSDBContext _context;

        public AseguradoDAO(DSDBContext context)
        {
            _context = context;
        }*/

        public AseguradoDTO VerRegistrosAsegurado(string asegurado)
        {
            try
            {
                var data = _context.Asegurados
                   .Where(a => a.Nombre == asegurado)
                   .Select(a => new AseguradoDTO
                   {
                       Cedula = a.Cedula,
                       Nombre = a.Nombre,
                       Apellido = a.Apellido
                   });

                return data.Single();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de Asegurados" + asegurado, ex.Message, ex);
            }

        }
    
       
        public Task Add(AseguradoDTO aseguradoDTO)
        {
            Asegurado asegurado = new Asegurado();
            asegurado.Cedula = aseguradoDTO.Cedula;
            asegurado.Nombre = aseguradoDTO.Nombre;
            asegurado.Apellido = aseguradoDTO.Apellido;
            _context.Asegurados.Add(asegurado);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(AseguradoDTO aseguradoDTO, int Cedula)
        {
            var itemToUpdate = _context.Asegurados.Find(Cedula);
            itemToUpdate.Nombre = aseguradoDTO.Nombre;
            _context.DbContext.SaveChanges();

            return Task.CompletedTask;
        }

        public Task Delete(int Cedula)
        {
            var ItemToRemove = _context.Asegurados.Find(Cedula);
            _context.Asegurados.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public AseguradoDTO GetAsegurado(int cedula)
        {
            var query = _context.Asegurados
                .Where(a => a.Cedula == cedula)
                .Select(a => new AseguradoDTO
                {
                    Cedula = a.Cedula,
                    Nombre = a.Nombre,
                    Apellido = a.Apellido
                });
            return query.First();
        }
        
    }
}
