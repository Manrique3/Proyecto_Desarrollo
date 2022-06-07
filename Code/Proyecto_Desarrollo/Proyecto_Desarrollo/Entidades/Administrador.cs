using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Desarrollo.Entidades
{
    public class Administrador : Usuario
    {
        public int Id { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }



    }
}    
/*Add-Migration InitialCreate -----> Comando para iniciar la carpeta de migraciones, Donde esta el historial de migraciones?*/
/*Update-Database -----> Comando para actualizar la migracion al pasarla a la base de datos?*/
