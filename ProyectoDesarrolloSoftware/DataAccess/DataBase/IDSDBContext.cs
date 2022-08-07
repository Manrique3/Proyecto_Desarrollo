using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DataBase
{
    public interface IDSDBContext
    {

        DbContext DbContext 
        {
            get;
        }

        DbSet<Vehiculo> Vehiculos 
        {
            get; set;
        }

        DbSet<Marca> Marcas
        { 
            get; set;
        }

        DbSet<Usuario> Usuarios
        { 
            get; set;
        }

        DbSet<Administrador> Administradors
        { 
            get; set;
        } //Entidad Administrador

        DbSet<Poliza> Polizas 
        { 
            get; set; 
        } //Entidad de Polizas

        DbSet<Proveedor> Proveedores 
        { 
            get; set;
        }

        DbSet<Taller> Tallers 
        { 
            get; set;
        }

        DbSet<Perito> Peritos 
        {
            get; set; 
        } // Entidad Perito

        DbSet<Taller_Marca> Taller_Marcas 
        { 
            get; set;
        }

        DbSet<Proveedor_Marca> ProvMarcas 
        {
            get; set; 
        }

        DbSet<Pieza> Piezas 
        { 
            get; set;
        }

        DbSet<Asegurado> Asegurados 
        { 
            get; set;
        }

        DbSet<Incidente> Incidentes 
        { 
            get; set;
        } //Entidad de Incidentes

        DbSet<Cotizacion> Cotizacions 
        { 
            get; set;
        } //Entidad de Cotizacion

        DbSet<Pieza_Proveedor> Pieza_Proveedor 
        {
            get; set;
        }

        DbSet<Administrador_Cotizacion> Administrador_Cotizacion 
        { 
            get; set; 
        }

        DbSet<Cotizacion_Proveedor> Cotizacion_Proveedor 
        { 
            get; set; 
        }

        DbSet<Cotizacion_Taller> Cotizacion_Taller 
        { 
            get; set;
        }

        DbSet<Incidente_Pieza> Incidente_Pieza 
        { 
            get; set; 
        }

        DbSet<Pedido> Pedidos 
        { 
            get; set;
        }


    }
}
