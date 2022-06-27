namespace ProyectoDesarrolloSoftware.DTO
{
    public class PolizaDTO
    {
        public int Id_Poliza { get; set; }
        public string Tipo { get; set; }
        public int fk_vehiculo { get; set; }
        public int fk_asegurado { get; set; }


    }
}
