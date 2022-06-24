using ProyectoDesarrolloSoftware.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations
{
    public class MockMarcaData : IMarca
    {
        private List<MarcaDTO> marcas = new List<MarcaDTO>()
        {
            new MarcaDTO()
            {
                Id = 1,
                Name = "TOYOTA"
            },

            new MarcaDTO()
            {
                Id = 2,
                Name = "HONDA"
            },
            new MarcaDTO()
            {
                Id = 2,
                Name = "MITSUBISHI"
            }

        };

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
            return marcas;
        }
    }
}
