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

        public DbSet<Taller> Tallers { get; set; }

        public DbSet<Taller_Marca> Taller_Marcas { get; set; }

        public DbSet<Taller_Marca> TallerMarcas { get; set; }

        public DbSet<Proveedor_Marca> ProvMarcas { get; set; }
        
        public DbSet<Pieza> Piezas { get; set; }

        public DbSet<Asegurado> Asegurados { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Proveedor_Marca>()
                .HasKey(c => new { c.IDMarca, c.Id_proveedor });

            modelBuilder.Entity<Taller_Marca>()
                .HasKey(t => new { t.IDMarca, t.Id_Taller });

            modelBuilder.Entity<Pieza_Proveedor>()
                .HasKey(p => new { p.Id_Pieza, p.Id_proveedor });
        }

    }
}