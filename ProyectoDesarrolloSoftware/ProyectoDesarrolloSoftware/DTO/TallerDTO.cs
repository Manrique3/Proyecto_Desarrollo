namespace ProyectoDesarrolloSoftware.DTO
{
    public class TallerDTO
    {
        private int Id_Taller { get; set; }
        private string Nombre { get; set; }
        public virtual LugarDTO Lugar { get; set; }

    }
}
