using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Pedido
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Pedido { get; set; }

        [Column(Order = 2)]
        [RegularExpression(@"Con Orden de Compra|Facturado")]
        public string estatus { get; set; }

        [Column(Order = 3)]
        public double pago_total { get; set; }

        [Column(Order = 4)]
        public int numero_factura { get; set; }

        public int? fk_proveedor_prov_cot { get; set; }

        public int? fk_cotizacion_prov_cot { get; set; }
        
        public int? fk_taller_taller_cot { get; set; }
        
        public int? fk_cotizacion_taller_cot { get; set; }

        [ForeignKey("fk_proveedor_prov_cot,fk_cotizacion_prov_cot")]
        public virtual Cotizacion_Proveedor Cotizacion_Proveedor { get; set; }

        [ForeignKey("fk_taller_taller_cot,fk_cotizacion_taller_cot")]
        public virtual Cotizacion_Taller Cotizacion_Taller { get; set; }


    }
}
