namespace ProyectoDesarrolloSoftware.DTO
{
    public class ProveedorDTO
    {
        private int Id_Proveedor { get; set; }
        private string Nombre { get; set; }
        public virtual LugarDTO Lugar { get; set; }

    }
}
