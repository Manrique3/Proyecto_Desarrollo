using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.DTO
{
    public class PedidoDTO
    {
        public int Id_Pedido { get; set; }

        [RegularExpression(@"Con Orden de Compra|Facturado")]
        public string estatus { get; set; }
        public double Pago_Total { get; set; }
        public int numero_factura { get; set; }
        public int fk_proveedor_prov_cotizacion { get; set; }
        public int fk_cotizacion_prov_cot { get; set; }
        public int fk_taller_taller_cot { get; set; }
        public int fk_cotizacion_taller_cot { get; set; }


    }
}
