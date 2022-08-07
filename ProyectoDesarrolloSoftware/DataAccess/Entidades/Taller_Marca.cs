using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Taller_Marca
    {
        [Key, Column(Order = 1)]
        public int IDMarca { get; set; }

        [Key, Column(Order = 2)]
        public int Id_Taller { get; set; }

        [ForeignKey("IDMarca")]
        public Marca Marca { get; set; }

        [ForeignKey("Id_Taller")]
        public Taller Taller { get; set; }
    }
}
