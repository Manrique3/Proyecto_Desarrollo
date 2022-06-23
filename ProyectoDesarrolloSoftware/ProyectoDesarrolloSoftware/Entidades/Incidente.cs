using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Incidente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Incidente { get; set; }
        [RegularExpression(@"Pendiente|Evaluado|Evaluado_Culpable|EvaluadoSoloTerceros")]
        public string estadoEv { get; set; }
        public int fk_vehiculo { get; set; }
        [ForeignKey("fk_vehiculo")]
        public virtual Vehiculo Vehiculo { get; set; }


        
    }
}
