using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public abstract class Poliza
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Poliza { get; set; }
        //La poliza tiene lista de Administradores?
        public virtual ICollection<Asegurado> Asegurados { get; set; } // No puede ser NULL

        public Vehiculo Vehiculo { get; set; } // No puede ser NULL

    }
}
