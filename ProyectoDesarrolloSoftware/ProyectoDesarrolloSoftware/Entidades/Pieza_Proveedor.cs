using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Pieza_Proveedor
    { // Tabla de Muchos a Muchos de Pieza a Proveedor

        [Key, Column(Order = 1)]
        public int Id_Pieza { get; set; }

        [Key, Column(Order = 2)]
        public int Id_proveedor { get; set; }
        public int cantidad { get; set; }

        [ForeignKey("Id_Pieza")]
        public Pieza Pieza { get; set; }

        [ForeignKey("Id_proveedor")]
        public Proveedor Proveedor { get; set; }
    }
}
