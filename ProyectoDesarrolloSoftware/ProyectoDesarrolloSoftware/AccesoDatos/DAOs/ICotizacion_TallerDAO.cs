using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
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
