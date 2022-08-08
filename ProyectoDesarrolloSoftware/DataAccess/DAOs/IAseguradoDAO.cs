using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IAseguradoDAO
    {
        public AseguradoDTO VerRegistrosAsegurado(string asegurado);
        public Task Add(AseguradoDTO aseguradoDTO);
        public Task update(AseguradoDTO aseguradoDTO, int Cedula);
        public Task Delete(int Cedula);
        public AseguradoDTO GetAsegurado(int Cedula);


    }
}
