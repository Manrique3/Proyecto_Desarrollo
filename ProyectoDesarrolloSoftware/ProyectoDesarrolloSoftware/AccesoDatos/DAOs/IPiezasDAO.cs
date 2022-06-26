using NUnit.Framework;
using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IPiezasDAO
    {
        public List<PiezaDTO> GetListaPiezasByName(string Nombre);
        public Task Add(PiezaDTO piezaDTO);
        public Task update(PiezaDTO piezaDTO, int Id_Pieza);
        public Task delete(int Id_Pieza);
        public PiezaDTO GetPieza(int Id_Pieza);

    }
}
