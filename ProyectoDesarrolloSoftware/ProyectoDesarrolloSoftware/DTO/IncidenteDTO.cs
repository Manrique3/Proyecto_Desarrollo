namespace ProyectoDesarrolloSoftware.DTO
{
    public class IncidenteDTO
    {
        public int Id_Incidente { get; set; }
        public string estadoEv { get; set; }

        public VehiculoDTO vehiculo_tercero { get; set; }
        public PolizaDTO poliza { get; set; } 


    }
}
