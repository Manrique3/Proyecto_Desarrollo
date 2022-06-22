using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Taller 
    {
        [Key]
        public int Id_Taller { get; set; }
        public string Nombre { get; set; }
        public int fk_lugar { get; set; }
        [ForeignKey("fk_lugar")]
        public virtual Lugar Lugar { get; set; }
    }
}
