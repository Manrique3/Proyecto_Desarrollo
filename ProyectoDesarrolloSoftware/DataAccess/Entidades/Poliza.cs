using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Poliza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Poliza { get; set; }
        //La poliza tiene lista de Administradores?
        [Required]
        [RegularExpression(@"Cobertura_Completa|Daño_a_Terceros")]
        public string Tipo { get; set; }

        public string fk_vehiculo { get; set; }
        [ForeignKey("fk_vehiculo")]
        [Required]
        public virtual Vehiculo Vehiculo { get; set; }
        // No puede ser NULL

        public int fk_asegurado { get; set; }
        [ForeignKey("fk_asegurado")]
        [Required]
        public virtual Asegurado Asegurado { get; set; }
    }
}
