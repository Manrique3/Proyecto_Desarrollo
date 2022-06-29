using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
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
