
using ProyectoDesarrolloSoftware.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations
{
    public class MarcaDataDAO : IMarcaDAO
    {
        private DSDBContext _context;
        public MarcaDataDAO(DSDBContext context)
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
            throw new NotImplementedException();
        }

        public List<MarcaDTO> GetMarcas()
        {
            /* var data = from a in _context.Marcas                      
                        select a;
              foreach (var a in data)
              {
                  System.Console.WriteLine(a.Name + " ");
              }]*/
            var data = _context.Marcas
                .Include(b => b.Marcas);

            return null;

           //return _marca.Marcas.ToList(); // Se escribe la palabra Marcas, Referencia a la tabla de marca de DBContext 
        }
    }
}
