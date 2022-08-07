using System.ComponentModel.DataAnnotations;
namespace ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO
{
    public class Cotizacion_proveedorDTO
    {
        public int Id_Cotizacion { get; set; }
        public int Id_Proveedor { get; set; }

        [RegularExpression(@"Pendiente|Declinado|Cotizado|Con Orden de Compra|Facturado")]
        public string estatus { get; set; }
        public string Nombre_Proveedor { get;  set; } //NOMBRE DEL PROVEEDOR DE LA COTIZACION 
        public int Id_Pieza { get;  set; } //ID DE LA PIEZA EN LA COTIZACION
                                                   // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set
        public string Nombre_Pieza { get;  set; } // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set


    }
}
