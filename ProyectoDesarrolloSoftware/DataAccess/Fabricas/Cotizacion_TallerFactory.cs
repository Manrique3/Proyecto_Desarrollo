using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class Cotizacion_TallerFactory
    {
        public static Cotizacion_TallerDAO CreateProviderDB()
        {
            return new Cotizacion_TallerDAO();
        }
    }
}
