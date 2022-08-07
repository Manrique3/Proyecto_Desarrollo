using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class TallerDAO : ITallerDAO
    {
        private DSDBContext _context;
        public TallerDAO(DSDBContext context)
        {
            _context = context;

        }

        public Task AddTaller(TallerDTO tallerDTO)
        {
            try
            {

                Taller _taller = new Taller();

                //_marca.IDMarca = marca.IDMarca;
                _taller.Nombre = tallerDTO.Nombre;
                _taller.Nombre = tallerDTO.Lugar;
                _context.Tallers.Add(_taller);
                _context.SaveChanges();
                return Task.CompletedTask;


            }
            catch (Exception e)
            {
                throw new Exception("Ocurrio un error en la base de datos" + e);
            }
        }        
        public Task DeleteTaller(int Id_Taller)
        {
            var data = _context.Tallers.Find(Id_Taller); // Se Debe eliminar por ID, no por objeto.
            _context.Tallers.Remove(data);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public TallerDTO GetTaller(int Id_Taller)
        {
            var query = _context.Tallers
                   .Where(b => b.Id_Taller == Id_Taller)
                   .Select(b => new TallerDTO
                   {
                       Id_Taller = b.Id_Taller,
                       Nombre = b.Nombre,
                       Lugar = b.Lugar,
                   });

            return query.First();
        }

        public List<TallerDTO> GetTalleres() //
        {
            var data = _context.Tallers
                 .Select(b => new TallerDTO
                 {
                     Id_Taller = b.Id_Taller,
                     Nombre = b.Nombre,
                     Lugar = b.Lugar,

                 }).ToList();

            return data;
        }

        public Task UpdateTaller(TallerDTO taller, int Id_Taller)
        {
            var data = _context.Tallers.Find(Id_Taller);
            data.Nombre = taller.Nombre;
            data.Lugar = taller.Lugar;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        

        
        
    }
}
