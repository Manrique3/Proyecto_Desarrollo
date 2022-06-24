namespace ProyectoDesarrolloSoftware.DTO
{
    public class Incidente_PiezaDTO
    {
        private int Id_Pieza { get; set; }
        private int Id_Incidente { get; set; }
        private PiezaDTO Pieza { get; set; }
        private IncidenteDTO Incidente { get; set; }

    }
}
