using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IPolizaDAO
    {
        public PolizaDTO GetPoliza(int Id_Poliza);
        public Task AddVehiculo(VehiculoDTO vehiculoDTO);
        public Task AddPoliza(PolizaDTO polizaDTO);
        public Task updateTipo(PolizaDTO polizaDTO, int Id_Poliza);
        public Task Delete(int Id_Poliza);
    }
}
