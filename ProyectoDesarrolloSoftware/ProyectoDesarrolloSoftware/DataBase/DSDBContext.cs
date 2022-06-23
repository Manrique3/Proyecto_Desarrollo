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
        public DbSet<Administrador> Administradors { get; set; } //Entidad Administrador
        public DbSet<Poliza> Polizas { get; set; } //Entidad de Polizas
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Taller> Tallers { get; set; }
        public DbSet<Perito> Peritos { get; set; } // Entidad Perito
        public DbSet<Taller_Marca> Taller_Marcas { get; set; }
        public DbSet<Proveedor_Marca> ProvMarcas { get; set; }
        public DbSet<Pieza> Piezas { get; set; }
        public DbSet<Asegurado> Asegurados { get; set; }
        public DbSet<Incidente> Incidentes { get; set; } //Entidad de Incidentes
        public DbSet<Cotizacion> Cotizacions { get; set; } //Entidad de Cotizacion
        public DbSet<Pieza_Proveedor> Pieza_Proveedor { get; set; }
        public DbSet<Administrador_Cotizacion> Administrador_Cotizacion { get; set; }
        public DbSet<Cotizacion__Pieza> Cotizacion__Pieza { get; set; }
        public DbSet<Cotizacion_Proveedor> Cotizacion_Proveedor { get; set; }
        public DbSet<Cotizacion_Taller> Cotizacion_Taller { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Proveedor_Marca>()
                .HasKey(c => new { c.IDMarca, c.Id_proveedor });

            modelBuilder.Entity<Taller_Marca>()
                .HasKey(t => new { t.IDMarca, t.Id_Taller });

            modelBuilder.Entity<Pieza_Proveedor>()
                .HasKey(p => new { p.Id_Pieza, p.Id_proveedor });

            modelBuilder.Entity<Administrador_Cotizacion>()
                .HasKey(ac => new { ac.Id_Administrador, ac.Id_Cotizacion });

            modelBuilder.Entity<Cotizacion__Pieza>()
                .HasKey(cp => new { cp.Id_Cotizacion, cp.Id_Pieza });

            modelBuilder.Entity<Cotizacion_Proveedor>()
                .HasKey(cpe => new { cpe.Id_Cotizacion, cpe.Id_Proveedor, cpe.Id_Pieza_Pieza_Proveedor, cpe.Id_Proveedor_Pieza_Proveedor });

            modelBuilder.Entity<Cotizacion_Taller>()
                .HasKey(CT => new { CT.Id_Cotizacion, CT.Id_Taller });



        }

    }
}