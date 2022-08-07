using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface ICotizacionDAO
    {
        public List<CotizacionDTO> GetListaCotizacionesById(int Id_Cotizacion);
        public Task Add(CotizacionDTO cotizacionDTO);
        public Task Update(CotizacionDTO cotizacionDTO, int Id_Cotizacion);
        public Task Delete(int Id_Cotizacion);
        public CotizacionDTO GetCotizacion(int Id_Cotizacion);
    }
}
