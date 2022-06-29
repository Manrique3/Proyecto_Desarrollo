using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface Icotizacion_proveedorDAO
    {
        public List<Cotizacion_proveedorDTO> GetListaCotizacionesDeProveedores();//(int IDMarca, int Id_Taller);
        public Task Add(Cotizacion_proveedorDTO cotizacion_ProveedorDTO);

        ///public Task update(Taller_MarcaDTO taller_MarcaDTO, int IDMarca, int Id_Taller);
        public Task delete(int Id_Cotizacion, int Id_Taller);
        public List<Cotizacion_proveedorDTO> GetCotizacionDeProveeor(int ID_Cotizacion);
        public List<Cotizacion_proveedorDTO> GetCotizacionProveedor(int Id_Cotizacion);
    }
}
