namespace ProyectoDesarrolloSoftware.DTO
{
    public class Administrador_CotizacionDTO
    {
        public int Id_administrador { get; set; }
        public int Id_cotizacion { get; set; }
        public AdministradorDTO administradorDTO { get; set; }
        public CotizacionDTO cotizacionDTO { get; set; }


    }
}
