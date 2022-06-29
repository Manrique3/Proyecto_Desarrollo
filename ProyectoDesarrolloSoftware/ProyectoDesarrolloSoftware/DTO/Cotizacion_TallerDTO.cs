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
        public int Id_Cotizacion { get; set; }
        public int Id_Taller { get; set; }

        [RegularExpression(@"Pendiente|Cotizado|Con Orden de Compra|Facturado")]
        public string estatus { get; set; }
        public int cantidad_piezas_reparar { get; set; }
        public double costo_reparacion { get; set; }
        public int tiempo_reparacion { get; set; }


    }
}
