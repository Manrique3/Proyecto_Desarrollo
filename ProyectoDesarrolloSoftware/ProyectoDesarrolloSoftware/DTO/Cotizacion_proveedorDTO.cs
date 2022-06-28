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
        public int Id_Pieza_Pieza_Proveedor { get; set; }
        public int Id_Proveedor_Pieza_Proveedor { get; set; }


    }
}
