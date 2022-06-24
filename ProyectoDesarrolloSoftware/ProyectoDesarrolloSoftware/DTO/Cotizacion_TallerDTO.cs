using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.DTO
{
    public class Cotizacion_TallerDTO
    {
        private int Id_Cotizacion { get; set; }
        private int Id_Taller { get; set; }

        [RegularExpression(@"Pendiente|Cotizado|Con Orden de Compra|Facturado")]
        private string estatus { get; set; }
        private int cantidad_piezas_reparar { get; set; }
        private double costo_reparacion { get; set; }
        private int tiempo_reparacion { get; set; }
        private CotizacionDTO Cotizacion { get; set; }
        private TallerDTO Taller { get; set; }


    }
}
