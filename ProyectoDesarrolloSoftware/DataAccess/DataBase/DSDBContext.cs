using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.Entidades;

namespace ProyectoDesarrolloSoftware.DataAccess.DataBase
{
    public class DSDBContext : DbContext, IDSDBContext
    {
        public DSDBContext(DbContextOptions<DSDBContext> options)
           : base(options)
        {
        }

        public DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        public virtual DbSet<Vehiculo> Vehiculos { get; set; }
        public virtual DbSet<Marca> Marcas { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Administrador> Administradors { get; set; } //Entidad Administrador
        public virtual DbSet<Poliza> Polizas { get; set; } //Entidad de Polizas
        public virtual DbSet<Proveedor> Proveedores { get; set; }
        public virtual DbSet<Taller> Tallers { get; set; }
        public virtual DbSet<Perito> Peritos { get; set; } // Entidad Perito
        public virtual DbSet<Taller_Marca> Taller_Marcas { get; set; }
        public virtual DbSet<Proveedor_Marca> ProvMarcas { get; set; }
        public virtual DbSet<Pieza> Piezas { get; set; }
        public virtual DbSet<Asegurado> Asegurados { get; set; }
        public virtual DbSet<Incidente> Incidentes { get; set; } //Entidad de Incidentes
        public virtual DbSet<Cotizacion> Cotizacions { get; set; } //Entidad de Cotizacion
        public virtual DbSet<Pieza_Proveedor> Pieza_Proveedor { get; set; }
        public virtual DbSet<Administrador_Cotizacion> Administrador_Cotizacion { get; set; }
        public virtual DbSet<Cotizacion_Proveedor> Cotizacion_Proveedor { get; set; }
        public virtual DbSet<Cotizacion_Taller> Cotizacion_Taller { get; set; }
        public virtual DbSet<Incidente_Pieza> Incidente_Pieza { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }

        

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

            modelBuilder.Entity<Cotizacion_Proveedor>()
                .HasKey(cpe => new { cpe.Id_Cotizacion, cpe.Id_Proveedor });

            modelBuilder.Entity<Cotizacion_Taller>()
                .HasKey(CT => new { CT.Id_Cotizacion, CT.Id_Taller });

            modelBuilder.Entity<Incidente_Pieza>()
                .HasKey(InPi => new { InPi.Id_Pieza, InPi.Id_Incidente });



        }

    }
}