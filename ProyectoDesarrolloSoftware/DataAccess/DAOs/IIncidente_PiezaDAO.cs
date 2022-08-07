using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IIncidente_PiezaDAO
    {
        public Task Add(Incidente_PiezaDTO incidente_piezaDTO);
        public Task Delete(int Id_Pieza, int Id_Incidente);
        public List<Incidente_PiezaDTO> GetIncidente_Pieza(int Id_Incidente);

    }
}
