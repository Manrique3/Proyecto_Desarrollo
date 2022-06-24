namespace ProyectoDesarrolloSoftware.DTO
{
    public class Proveedor_MarcaDTO
    {
        private int Id_Proveedor { get; set; }
        private int Id_Marca { get; set; }
        private ProveedorDTO Proveedor { get; set; }
        private MarcaDTO Marca  { get; set; }
    }
}
