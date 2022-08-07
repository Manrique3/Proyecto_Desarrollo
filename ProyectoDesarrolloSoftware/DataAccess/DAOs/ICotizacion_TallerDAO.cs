using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface ICotizacion_TallerDAO
    {
        public List<Cotizacion_TallerDTO> GetListaCotizacionDeTallerById(int Id_Cotizacion);
        public Task Add(Cotizacion_TallerDTO cotizacion_tallerDTO, int Id_Cotizacion);
        public Task update(Cotizacion_TallerDTO cotizacion_tallerDTO, int Id_Cotizacion);
        public Task delete(int Id_Cotizacion);
        public Cotizacion_TallerDTO GetCotizacionTaller(int Id_Cotizacion);
    }
}
