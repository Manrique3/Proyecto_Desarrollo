using System.Runtime.InteropServices;

namespace ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO
{
    public class Pieza_ProveedorDTO
    {
        public int Id_Pieza { get; set; }
        public int Id_Proveedor { get; set; }
        public int cantidad { get; set; }
        public string Nombre_Proveedor { get;  set; } // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set
        public string Nombre_Pieza { get;  set; } // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set
    }
}
