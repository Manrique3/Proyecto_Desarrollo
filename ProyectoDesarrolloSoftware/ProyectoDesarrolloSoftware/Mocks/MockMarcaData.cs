using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations
{
    public class MockMarcaData : IMarcaDAO
    {
        private List<MarcaDTO> marcas = new List<MarcaDTO>()
        {
            new MarcaDTO()
            {
                IDMarca =1,
                Nombre = "TOYOTA"
            },

            new MarcaDTO()
            {
                IDMarca =2,
                Nombre = "HONDA"
            },
            new MarcaDTO()
            {
                IDMarca =3,
                Nombre = "MITSUBISHI"
            }

        };

        public MarcaDTO AddMarca(MarcaDTO marca)
        {            
            marcas.Add(marca);
            return marca;
        }

        public void DeleteMarca(MarcaDTO marca)
        {
            marcas.Remove(marca);
        }

        public MarcaDTO EditMarca(MarcaDTO marca)
        {
            var ExisteMarca = GetMarca(marca.IDMarca);
            ExisteMarca.Nombre = marca.Nombre;
            return ExisteMarca;
        }

        public MarcaDTO GetMarca(int id)
        {
            return marcas.SingleOrDefault(x => x.IDMarca == id);
        }

        public List<MarcaDTO> GetMarcas()
        {
            return marcas;
        }
    }
}
