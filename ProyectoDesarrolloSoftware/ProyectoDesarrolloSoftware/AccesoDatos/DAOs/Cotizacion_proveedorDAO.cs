using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public class Cotizacion_proveedorDAO : Icotizacion_proveedorDAO
    {
        public readonly DSDBContext _context;

        public Cotizacion_proveedorDAO(DSDBContext context)
        {
            _context = context;
        }

        public Task Add(Cotizacion_proveedorDTO cotizacion_ProveedorDTO)
        {
            throw new NotImplementedException();
        }

        public Task delete(int Id_Cotizacion, int Id_Taller)
        {
            throw new NotImplementedException();
        }

        public List<Cotizacion_proveedorDTO> GetCotizacionDeProveeor(int ID_Cotizacion)
        {
            throw new NotImplementedException();
        }

        public List<Cotizacion_proveedorDTO> GetCotizacionProveedor(int Id_Cotizacion)
        {
            throw new NotImplementedException();
        }

        public List<Cotizacion_proveedorDTO> GetListaCotizacionesDeProveedores()
        {
            try
            {
                var query = (from CP in _context.Cotizacion_Proveedor
                             join C in _context.Cotizacions on CP.Id_Cotizacion equals C.Id_Cotizacion
                             join P in _context.Proveedores on CP.Id_Proveedor equals P.Id_proveedor
                             where C.Id_Cotizacion == CP.Id_Cotizacion
                             && P.Id_proveedor == CP.Id_Proveedor
                             select new Cotizacion_proveedorDTO
                             {
                                 Id_Cotizacion = C.Id_Cotizacion,   // Usa Id_Taller del new Taller_MarcaDTO no del Parametro
                                 Id_Proveedor = P.Id_proveedor,     // Usa IDMarca del new Taller_MarcaDTO no del Parametro
                                 Nombre_Proveedor = P.Nombre,       // Usa Nombre del taller del new Taller_MarcaDTO no del Parametro
                                                                    // Usa Nombre de marca del new Taller_MarcaDTO no del Parametro
                             }).ToList();

                return query;
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }
    }
}
