using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Pieza
    {
        [Key]
        public int Id_Pieza { get; set; }
        public string Nombre { get; set; }
        public int Descripcion { get; set; }
    }
}
