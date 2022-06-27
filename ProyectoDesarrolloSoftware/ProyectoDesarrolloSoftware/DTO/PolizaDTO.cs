namespace ProyectoDesarrolloSoftware.DTO
{
    public class PolizaDTO
    {
        private int Id_Poliza { get; set; }
        private string Tipo { get; set; }
        private VehiculoDTO Vehiculo { get; set; }
        private AseguradoDTO Asegurado { get; set; }

    }
}
