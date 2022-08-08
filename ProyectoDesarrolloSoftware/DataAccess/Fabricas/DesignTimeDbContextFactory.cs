using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProyectoDesarrolloSoftware.DataAccess.DataBase;

namespace ProyectoDesarrolloSoftware.Fabricas
{
    public class DesignTimeDBContextFactory : IDesignTimeDbContextFactory<DSDBContext>
    {

#pragma warning disable CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        public DSDBContext CreateDbContext(string[]? args)
#pragma warning restore CS8632 // La anotación para tipos de referencia que aceptan valores NULL solo debe usarse en el código dentro de un contexto de anotaciones "#nullable".
        {
            var builder = new DbContextOptionsBuilder<DSDBContext>();
            var connectionString = "Server=localhost;Database=Desarrollo_Software;Port=5432;User Id=postgres;Password=admin"; //Conexion a Base de datos
            builder.UseNpgsql(connectionString);
            return new DSDBContext(builder.Options);
        }
    }
}
