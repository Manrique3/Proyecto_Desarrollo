using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using ProyectoDesarrolloSoftware.Entidades;

namespace ProyectoDesarrolloSoftware.DataBase
{
    public class DSDBContext : DbContext
    {
        public DSDBContext(DbContextOptions<DSDBContext> options)
            : base(options)
        {


        }

        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Lugar> Lugares { get; set; }
        
        public DbSet<Proveedor> Proveedores { get; set; }

        public DbSet<Proveedor_Marca> ProvMarcas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor_Marca>()
                .HasKey(c => new { c.IDMarca, c.Id_proveedor });
        }
    }
}