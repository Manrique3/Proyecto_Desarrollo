using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Desarrollo.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public String Username { get; set; }
        private String Passsword { get; set; }
    }
}
