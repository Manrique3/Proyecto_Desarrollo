namespace ProyectoDesarrolloSoftware.DTO
{
    public class ProveedorDTO
    {
        public int Id_Proveedor { get; set; }
        public string Nombre { get; set; }
        public virtual LugarDTO Lugar { get; set; }

    }
}
