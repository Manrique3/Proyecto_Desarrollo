using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IIncidente_PiezaDAO
    {
        public Task Add(Incidente_PiezaDTO incidente_piezaDTO);
        public Task Delete(int Id_Pieza, int Id_Incidente);
        public List<Incidente_PiezaDTO> GetIncidente_Pieza(int Id_Incidente);

    }
}
