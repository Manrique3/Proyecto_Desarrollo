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

        DbContext DbContext
        {
            get
            {
                return this;
            }
        }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
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
        public DbSet<Cotizacion_Proveedor> Cotizacion_Proveedor { get; set; }
        public DbSet<Cotizacion_Taller> Cotizacion_Taller { get; set; }
        public DbSet<Incidente_Pieza> Incidente_Pieza { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }

        DbContext IDSDBContext.DbContext => throw new System.NotImplementedException();

        DbSet<Vehiculo> IDSDBContext.Vehiculos { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Usuario> IDSDBContext.Usuarios { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Administrador> IDSDBContext.Administradors { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Poliza> IDSDBContext.Polizas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Proveedor> IDSDBContext.Proveedores { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Taller> IDSDBContext.Tallers { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Perito> IDSDBContext.Peritos { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Taller_Marca> IDSDBContext.Taller_Marcas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Proveedor_Marca> IDSDBContext.ProvMarcas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Pieza> IDSDBContext.Piezas { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Asegurado> IDSDBContext.Asegurados { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Incidente> IDSDBContext.Incidentes { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Cotizacion> IDSDBContext.Cotizacions { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Pieza_Proveedor> IDSDBContext.Pieza_Proveedor { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Administrador_Cotizacion> IDSDBContext.Administrador_Cotizacion { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Cotizacion_Proveedor> IDSDBContext.Cotizacion_Proveedor { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Cotizacion_Taller> IDSDBContext.Cotizacion_Taller { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Incidente_Pieza> IDSDBContext.Incidente_Pieza { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
        DbSet<Pedido> IDSDBContext.Pedidos { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

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