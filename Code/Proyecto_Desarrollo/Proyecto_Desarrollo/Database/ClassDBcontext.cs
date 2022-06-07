using Microsoft.EntityFrameworkCore;
using Proyecto_Desarrollo.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_Desarrollo.Database
{
    public class ClassDBcontext : DbContext
    {

        public ClassDBcontext(DbContextOptions<ClassDBcontext> options) : base(options)
        {

        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        public virtual DbSet<Usuario> Usuarios { set; get; }


    }


}
