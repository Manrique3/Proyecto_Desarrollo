using System.Runtime.InteropServices;

namespace ProyectoDesarrolloSoftware.DTO
{
    public class Pieza_ProveedorDTO
    {
        public int Id_Pieza { get; set; }
        public int Id_Proveedor { get; set; }
        public int cantidad { get; set; }
        public string Nombre_Proveedor { get; internal set; }

        public string Nombre_Pieza { get; internal set; }
    }
}
