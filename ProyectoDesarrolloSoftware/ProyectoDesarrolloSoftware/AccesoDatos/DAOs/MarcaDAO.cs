
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations
{
    public class MarcaDAO : IMarcaDAO
    {
        private DSDBContext _context;
        public MarcaDAO(DSDBContext context)
        {
            _context = context;

        }
      
        public MarcaDTO AddMarca(MarcaDTO marca)
        {
            throw new NotImplementedException();
        }

        public void DeleteMarca(MarcaDTO marca)
        {
            throw new NotImplementedException();
        }

        public MarcaDTO EditMarca(MarcaDTO marca)
        {
            throw new NotImplementedException();
        }

        public MarcaDTO GetMarca(int Id)
        {
            try
            {
                var data = _context.Marcas
                .Where(b => b.IDMarca ==Id)
               .Select(b => new MarcaDTO
               {
                   IDMarca = b.IDMarca,
                   Nombre = b.Name,

               });

                
                return data.First();
            }
            catch (Exception e) { //System.InvalidCastException
                throw new Exception("Ocurrio un error en la base de datos" + e);
            }
                
        }

        public List<MarcaDTO> GetMarcas()
        {
            
            var data = _context.Marcas
                .Select(b => new MarcaDTO
                {
                    IDMarca = b.IDMarca,
                    Nombre = b.Name,

                }).ToList();

            return data;
         
        }
    }
}
