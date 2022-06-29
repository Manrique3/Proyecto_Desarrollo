using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.DTO
{
    public class Cotizacion_proveedorDTO
    {
        public int Id_Cotizacion { get; set; }
        public int Id_Proveedor { get; set; }

        [RegularExpression(@"Pendiente|Declinado|Cotizado|Con Orden de Compra|Facturado")]
        public string estatus { get; set; }
        public string Nombre_Proveedor { get; internal set; } //NOMBRE DEL PROVEEDOR DE LA COTIZACION
        public string Nombre_Pieza { get; internal set; } //NOMBRE DE LA PIEZA EN LA COTIZACION


    }
}
