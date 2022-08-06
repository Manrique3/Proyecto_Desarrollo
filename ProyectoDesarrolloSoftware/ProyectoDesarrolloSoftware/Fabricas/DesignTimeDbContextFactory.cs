using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProyectoDesarrolloSoftware.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Fabricas
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<MarcaDBContext>
    {

        public MarcaDBContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MarcaDBContext>();
            var connectionString = "Server=localhost;Database=Desarrollo_Software;Port=5432;User Id=postgres;Password=1234"; //Conexion a Base de datos
            builder.UseNpgsql(connectionString);
            return new MarcaDBContext(builder.Options);
        }
    }
}
