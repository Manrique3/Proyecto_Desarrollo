using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.Fabricas
{
    public class Taller_MarcaFactory
    {
        public static Taller_MarcaDAO CreateTallerMarcaDB()
        {
            return new Taller_MarcaDAO();
        }
    }
}
