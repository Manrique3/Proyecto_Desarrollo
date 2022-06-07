using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Desarrollo.Entidades
{
    public abstract class Usuario
    {
        protected int Id { get; set; }
        protected String Username { get; set; }
        protected String Passsword { get; set; }

       /* public Usuario(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Passsword = password;

        }     Se programa todos los metodos ya? */
    }
}
