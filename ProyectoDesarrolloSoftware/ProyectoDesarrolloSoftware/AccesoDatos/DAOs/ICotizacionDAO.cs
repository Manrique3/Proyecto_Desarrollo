using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface ICotizacionDAO
    {
        public List<CotizacionDTO> GetListaCotizacionesById(int Id_Cotizacion);
        public Task Add(CotizacionDTO cotizacionDTO);
        public Task update(CotizacionDTO cotizacionDTO, int Id_Cotizacion);
        public Task delete(int Id_Cotizacion);
        public CotizacionDTO GetCotizacion(int Id_Cotizacion);
    }
}
