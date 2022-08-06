using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase
{
    interface IMarcaDBContext
    {
        DbContext DSDBContext  //Puede ocasionar un error
        {
            get;
        }

        DbSet<Marca> Marcas
        {
            get; set;
        }
    }
}
