using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class Proveedor_MarcaFactory
    {        
        public static Proveedor_MarcaDAO CreateProveedor_MarcaDB()
        {
            return new Proveedor_MarcaDAO();
        }
    }
}
