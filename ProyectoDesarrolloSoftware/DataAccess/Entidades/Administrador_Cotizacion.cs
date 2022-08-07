using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Administrador_Cotizacion
    {
        [Key, Column(Order = 1)]
        public int Id_Administrador { get; set; }

        [Key, Column(Order = 2)]
        public int Id_Cotizacion { get; set; }
        
        [ForeignKey("Id_Administrador")]
        public Administrador Administrador { get; set; }

        [ForeignKey("Id_Cotizacion")]
        public Cotizacion Cotizacion { get; set; } 
    }
}
