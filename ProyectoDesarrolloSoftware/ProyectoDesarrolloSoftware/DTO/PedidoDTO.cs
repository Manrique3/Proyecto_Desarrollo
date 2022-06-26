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
        public virtual Cotizacion_proveedorDTO Cotizacion_Proveedor { get; set; }
        public virtual Cotizacion_TallerDTO Cotizacion_Taller { get; set; }

    }
}
