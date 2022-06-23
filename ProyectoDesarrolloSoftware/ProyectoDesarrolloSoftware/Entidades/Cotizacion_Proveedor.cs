using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Cotizacion_Proveedor
    {
        [Key, Column(Order = 1)]
        public int Id_Cotizacion { get; set; }

        [Key, Column(Order = 2)]
        public int Id_Proveedor { get; set; }

        [Column(Order = 3)]
        [RegularExpression(@"Pendiente|Declinado|Cotizado|Con Orden de Compra|Facturado")]
        public string estatus { get; set; }

        [Key, Column(Order = 4)]
        public int Id_Pieza_Pieza_Proveedor { get; set; }

        [Key, Column(Order = 5)]
        public int Id_Proveedor_Pieza_Proveedor { get; set; }

        [ForeignKey("Id_Cotizacion")]
        public Cotizacion Cotizacion { get; set; }

        [ForeignKey("Id_Proveedor")]
        public Proveedor Proveedor { get; set; }

        [ForeignKey("Id_Pieza_Pieza_Proveedor,Id_Proveedor_Pieza_Proveedor")]
        public Pieza_Proveedor Pieza_Proveedor { get; set; }





    }
}