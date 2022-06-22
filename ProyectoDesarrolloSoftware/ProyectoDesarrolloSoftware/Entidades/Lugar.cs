using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Lugar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_lugar { get; set; }
        [Required]
        public string nombre_lugar { get; set; }
        [Required]
        public string tipo_lugar { get; set; }
        public virtual ICollection<Lugar> fk_lugar { get; set; }


    }
}
