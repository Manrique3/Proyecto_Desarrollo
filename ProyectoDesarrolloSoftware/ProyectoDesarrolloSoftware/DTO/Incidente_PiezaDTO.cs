namespace ProyectoDesarrolloSoftware.DTO
{
    public class Incidente_PiezaDTO
    {
        public int Id_Pieza { get; set; }
        public int Id_Incidente { get; set; }
        public PiezaDTO Pieza { get; set; }
        public IncidenteDTO Incidente { get; set; }

    }
}
