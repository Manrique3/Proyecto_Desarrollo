using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class Pieza_ProveedorFactory
    {
        public static Pieza_ProveedorDAO CreateProviderDB()
        {
            return new Pieza_ProveedorDAO();
        }
    }
}
