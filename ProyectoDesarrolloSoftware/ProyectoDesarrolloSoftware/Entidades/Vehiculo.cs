using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDVehiculo { get; set; }
        [Required]
        public string Modelo { get; set; }
        [Required]
        public string Año { get; set; }
        public string color { get; set; }
        public int puestos { get; set; }
        [Required]
        public string Placa { get; set; }
        [Required]
        public string SerialMotor { get; set; }
        public int IDMarca { get; set; }
        [ForeignKey("IDMarca")]
        public virtual Marca Marca { get; set; }
    }
}
