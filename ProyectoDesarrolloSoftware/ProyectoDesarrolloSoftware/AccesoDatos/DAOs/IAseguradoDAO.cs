using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IAseguradoDAO
    {
        public List<AseguradoDTO> VerRegistrosAsegurado(string asegurado);
        public Task Add(AseguradoDTO aseguradoDTO);
        public Task update(AseguradoDTO aseguradoDTO, int Cedula);
        public Task Delete(int Cedula);
        public AseguradoDTO GetAsegurado(int Cedula);


    }
}
