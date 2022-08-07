using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IMarcaDAO
    {
        List<MarcaDTO>GetMarcas();

        MarcaDTO GetMarca(int Id);

        public Task AddMarca(MarcaDTO marca);

        public Task DeleteMarca(int Id_Marca); // Se eliminar por ID y no por objeto de Marca

        public Task EditMarca(MarcaDTO marca, int id_marca);


    }
}
