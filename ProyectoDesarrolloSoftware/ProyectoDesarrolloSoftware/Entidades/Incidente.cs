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

        [Required]        
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
        // No hay lista de Peritos, seria varios peritos analizando un incidente.
        // Un Adminsitrador genera un incidente
        // No hay lista de poliza, Ya que seria varias polizas cubren un solo incidente.
        
    }
}
