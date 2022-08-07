using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO
{
    public class PolizaDTO
    {
        public int Id_Poliza { get; set; }
        [RegularExpression(@"Cobertura_Completa|Daño_a_Terceros")]
        public string Tipo { get; set; }
        public string fk_vehiculo { get; set; }
        public int fk_asegurado { get; set; }

    }
}
