namespace ProyectoDesarrolloSoftware.DTO
{
    public class Proveedor_MarcaDTO
    {
        public int Id_Proveedor { get; set; }
        public int Id_Marca { get; set; }
        public ProveedorDTO Proveedor { get; set; }
        public MarcaDTO Marca  { get; set; }
    }
}
