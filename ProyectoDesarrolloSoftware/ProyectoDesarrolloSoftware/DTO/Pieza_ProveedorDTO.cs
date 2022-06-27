namespace ProyectoDesarrolloSoftware.DTO
{
    public class Pieza_ProveedorDTO
    {
        private int Id_Pieza { get; set; }
        private int Id_Proveedor { get; set; }
        private int cantidad { get; set; }
        private PiezaDTO Pieza { get; set; }
        private ProveedorDTO Proveedor { get; set; }

    }
}
