using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface ITallerDAO
    {
        public TallerDTO VerRegistrosTaller(string taller);
        public Task AddTaller(TallerDTO tallerDTO);
        public Task UpdateTaller(TallerDTO taller, int Id_Taller);
        public Task DeleteTaller(int Id_Taller);
        public TallerDTO GetTaller(int Id_Taller);
    }
}
