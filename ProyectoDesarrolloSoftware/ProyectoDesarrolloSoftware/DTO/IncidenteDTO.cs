namespace ProyectoDesarrolloSoftware.DTO
{
    public class IncidenteDTO
    {
        private int Id_Incidente { get; set; }
        private string estadoEv { get; set; }

        public VehiculoDTO vehiculo_tercero { get; set; }
        public PolizaDTO poliza { get; set; } 


    }
}
