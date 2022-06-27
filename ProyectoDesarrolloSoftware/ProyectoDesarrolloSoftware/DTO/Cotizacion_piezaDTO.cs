namespace ProyectoDesarrolloSoftware.DTO
{
    public class Cotizacion_piezaDTO
    {
        private int Id_Cotizacion { get; set; }
        private int Id_Pieza { get; set; }
        private CotizacionDTO Cotizacion { get; set; }
        private PiezaDTO Pieza { get; set; }
    }
}
