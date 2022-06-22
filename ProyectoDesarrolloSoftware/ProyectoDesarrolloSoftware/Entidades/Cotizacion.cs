using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Cotizacion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Cotizacion { get; set; }

        [Required]
        public virtual ICollection<Administrador> Administradors { get; set; }

        [Required]
        public virtual ICollection<Pieza> Piezas { get; set; } //Muchas Piezas en la tabla Cotizacion_Pieza

        public virtual ICollection<Proveedor> Proveedors { get; set; } //Muchos Proveedores en la tabla Cotizacion_Proveedor

        public virtual ICollection<Taller> Tallers { get; set; } //Muchos Talleres en la tabla Cotizacion_Taller





    }
}
