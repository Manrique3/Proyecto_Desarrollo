using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public class Taller_MarcaDAO : ITaller_MarcaDAO
    {
        private static DesignTimeDBContextFactory desing = new DesignTimeDBContextFactory(); // Cuando Inicie el DAO Pasa por la Fabrica y crea el objeto
        private IDSDBContext _context = desing.CreateDbContext(null);
        /*public readonly DSDBContext _context;

        public Taller_MarcaDAO(DSDBContext context)
        {
            _context = context;

        }*/

        public List<Taller_MarcaDTO> GetListaMarcaDeTallerById()//(int IDMarca, int Id_Taller)
        {
            try
            {
                var query = (from TM in _context.Taller_Marcas
                             join T in _context.Tallers on TM.Id_Taller equals T.Id_Taller
                             join M in _context.Marcas on TM.IDMarca equals M.IDMarca
                             where T.Id_Taller == TM.Id_Taller
                             && M.IDMarca == TM.IDMarca
                             select new Taller_MarcaDTO
                             {
                                 Id_Taller = T.Id_Taller, // Usa Id_Taller del new Taller_MarcaDTO no del Parametro
                                 IDMarca = M.IDMarca,   // Usa IDMarca del new Taller_MarcaDTO no del Parametro
                                 Nombre_Taller = T.Nombre, // Usa Nombre del taller del new Taller_MarcaDTO no del Parametro
                                 Nombre_Marca = M.Name,     // Usa Nombre de marca del new Taller_MarcaDTO no del Parametro
                             }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
        public Task Add(Taller_MarcaDTO taller_MarcaDTO)
        {
            
                Taller_Marca taller_marca = new Taller_Marca();
                taller_marca.Id_Taller = taller_MarcaDTO.Id_Taller;
                taller_marca.IDMarca = taller_MarcaDTO.IDMarca;                
                _context.Taller_Marcas.Add(taller_marca);
                _context.DbContext.SaveChanges();
                return Task.CompletedTask;
            
            /*catch (Exception e)
            {
                return e;
            }*/
        }

        public Task delete(int IDMarca, int Id_Taller)
        {
            var ItemToRemove = _context.Taller_Marcas.Find(IDMarca, Id_Taller);
            _context.Taller_Marcas.Remove(ItemToRemove);
            _context.DbContext.SaveChanges();
            return Task.CompletedTask;
        }

        public List<Taller_MarcaDTO> GetMarcaDeTaller(int Id_Taller) //Por id de Taller Muestra el taller y sus marcas
        {
            try
            {
                var query = (from TM in _context.Taller_Marcas //Query para buscar el taller con sus marcas
                             join T in _context.Tallers on TM.Id_Taller equals T.Id_Taller
                             join M in _context.Marcas on TM.IDMarca equals M.IDMarca
                             where TM.Id_Taller == Id_Taller                              
                             //&& TM.IDMarca == IDMarca
                             select new Taller_MarcaDTO
                             {                                 
                                 IDMarca = M.IDMarca,
                                 Id_Taller = T.Id_Taller,
                                 Nombre_Taller = T.Nombre,
                                 Nombre_Marca = M.Name,

                             }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new Exception("La lista no puede ser mostrada");
            }
        }
        public List<Taller_MarcaDTO> GetTallerDeMarca(int IDMarca) //Por id de Taller Muestra el taller y sus marcas
        {
            try
            {
                var query = (from TM in _context.Taller_Marcas //Query para buscar el taller con sus marcas
                             join T in _context.Tallers on TM.Id_Taller equals T.Id_Taller
                             join M in _context.Marcas on TM.IDMarca equals M.IDMarca
                             where TM.IDMarca == IDMarca
                             //|| T.Nombre = Nombre
                             //&& TM.Id_Taller == Id_Taller
                             select new Taller_MarcaDTO
                             {
                                 IDMarca = M.IDMarca,
                                 Id_Taller = T.Id_Taller,
                                 Nombre_Taller = T.Nombre,
                                 Nombre_Marca = M.Name,

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
