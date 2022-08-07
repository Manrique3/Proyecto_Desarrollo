using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;

namespace ProyectoDesarrolloSoftware.Fabricas
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<DSDBContext>
    {

        public DSDBContext CreateDbContext(string[]? args)
        {
            var builder = new DbContextOptionsBuilder<DSDBContext>();
            var connectionString = "Server=localhost;Database=Desarrollo_Software;Port=5432;User Id=postgres;Password=1234"; //Conexion a Base de datos
            builder.UseNpgsql(connectionString);
            return new DSDBContext(builder.Options);
        }
    }
}
