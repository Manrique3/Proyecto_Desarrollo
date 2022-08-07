using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs

{
    public interface IIncidenteDAO
    {
        public Task AddVehiculoTercaro(VehiculoDTO vehiculoDTO);
        public Task Add(IncidenteDTO incidenteDTO);
        public Task update(IncidenteDTO incidenteDTO, int Id_Incidente);
        public Task Delete(int Id_Incidente);
        public IncidenteDTO GetIncidente(int Id_Incidente);
    }
}
