using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.DTO;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface ITallerDAO
    {
        List<TallerDTO>GetTalleres();
        public Task AddTaller(TallerDTO tallerDTO);
        public Task UpdateTaller(TallerDTO taller, int Id_Taller);
        public Task DeleteTaller(int Id_Taller);
        public TallerDTO GetTaller(int Id_Taller);
    }
}
