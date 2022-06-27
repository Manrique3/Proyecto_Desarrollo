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
        private int Id_Cotizacion { get; set; }
        private int Id_Proveedor { get; set; }

        [RegularExpression(@"Pendiente|Declinado|Cotizado|Con Orden de Compra|Facturado")]
        private string estatus { get; set; }
        private int Id_Pieza_Pieza_Proveedor { get; set; }
        private int Id_Proveedor_Pieza_Proveedor { get; set; }
        private CotizacionDTO Cotizacion { get; set; }
        private ProveedorDTO Proveedor { get; set; }
        private Pieza_ProveedorDTO Pieza_Proveedor { get; set; }


    }
}
