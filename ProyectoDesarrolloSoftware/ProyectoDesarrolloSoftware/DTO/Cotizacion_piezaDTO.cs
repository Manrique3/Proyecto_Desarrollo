namespace ProyectoDesarrolloSoftware.DTO
{
    public class Cotizacion_piezaDTO
    {
        public int Id_Cotizacion { get; set; }
        public int Id_Pieza { get; set; }
        public CotizacionDTO Cotizacion { get; set; }
        public PiezaDTO Pieza { get; set; }
    }
}
