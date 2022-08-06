using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase
{
    public class MarcaDBContext : DbContext, IMarcaDBContext
    {
        public MarcaDBContext(DbContextOptions<MarcaDBContext> options) : base(options)
        {


        }

        public DbContext DSDBContext
        {
            get { return this; }

        }

        public virtual DbSet<Marca> Marcas 
        {
            get; set;

        }

    }
}
