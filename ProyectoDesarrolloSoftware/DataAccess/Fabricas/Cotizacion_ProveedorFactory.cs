using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class Cotizacion_ProveedorFactory
    {
        public static Cotizacion_ProveedorDAO CreateCotizacion_ProveedorDB()
        {
            return new Cotizacion_ProveedorDAO();
        }
    }
}
