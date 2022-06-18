using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Administrador
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Administrador { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public String Nombre { get; set; }        
        public String Email { get; set; }

        public virtual ICollection<Poliza>Polizas { get; set; }
        public virtual ICollection<Cotizacion> Cotizacions { get; set; }
        //El Administrador genera un incidente
        //public virtual ICollection<Incidente> Incidentes { get; set; }


    }
}
