using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class PolizaFactory
    {
        public static PolizaDAO CreatePolizaDB()
        {
            return new PolizaDAO();
        }
    }
}
