using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface ICotizacion_ProveedorDAO
    {
        List<Cotizacion_proveedorDTO> GetCotizacionesPorProveedor(int Id_Proveedor);

        List<Cotizacion_proveedorDTO> GetProveedoresPorCotizaciones(int Id_Cotizacion);

        public Task AddCotizacion_Proveedor(Cotizacion_proveedorDTO cotizacion_proveedor, int Id_Cotizacion);

        public Task DeleteCotizacion_Proveedor(int Id_Cotizacion, int Id_Proveedor); // Se eliminar por ID y no por objeto de Marca

        public Task EditCotizacion_Proveedor(Cotizacion_proveedorDTO cotizacion_proveedorDTO, int Id_Cotizacion, int Id_Proveedor);

    }
}
