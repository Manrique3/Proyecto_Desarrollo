namespace ProyectoDesarrolloSoftware.DTO
{
    public class IncidenteDTO
    {
        public int Id_Incidente { get; set; }
        public string estadoEv { get; set; }

        public string fk_vehiculo_tercero  { get; set; }
        public int fk_Poliza { get; set; } 


    }
}
