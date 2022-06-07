using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Desarrollo.Entidades
{
    public class Asegurado
    {
        public int Id { get; set; }
        public String Nombre { get; set; }

        public String Apellido { get; set; }

        public Asegurado(int id, string nombre, string apellido)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
        }

    }
}
