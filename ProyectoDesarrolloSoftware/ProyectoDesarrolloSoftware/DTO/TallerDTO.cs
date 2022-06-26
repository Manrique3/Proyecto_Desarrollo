namespace ProyectoDesarrolloSoftware.DTO
{
    public class TallerDTO
    {
        public int Id_Taller { get; set; }
        public string Nombre { get; set; }
        public virtual LugarDTO Lugar { get; set; }

    }
}
