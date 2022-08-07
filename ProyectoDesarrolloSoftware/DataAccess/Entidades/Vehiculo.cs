using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Vehiculo
    {
        [Key]
        public string Placa { get; set; }
        [Required]
        public string Modelo { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Año { get; set; }
        public string color { get; set; }
        public int puestos { get; set; }
        [Required]
        public string SerialMotor { get; set; }
        public int fk_marca { get; set; }
        [ForeignKey("fk_marca")]
        public virtual Marca Marca { get; set; }
    }
}
