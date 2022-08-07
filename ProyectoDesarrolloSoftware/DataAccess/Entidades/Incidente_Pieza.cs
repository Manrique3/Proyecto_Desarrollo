using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Incidente_Pieza
    {
        [Key, Column(Order = 1)]
        public int Id_Pieza { get; set; }

        [Key, Column(Order = 2)]
        public int Id_Incidente { get; set; }

        [ForeignKey("Id_Pieza")]
        public Pieza Pieza { get; set; }

        [ForeignKey("Id_Incidente")]
        public Incidente Incidente { get; set; }

     


    }
}
