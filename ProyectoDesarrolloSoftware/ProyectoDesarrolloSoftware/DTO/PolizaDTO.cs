namespace ProyectoDesarrolloSoftware.DTO
{
    public class PolizaDTO
    {
        public int Id_Poliza { get; set; }
        public string Tipo { get; set; }
        public VehiculoDTO Vehiculo { get; set; }
        public AseguradoDTO Asegurado { get; set; }

    }
}
