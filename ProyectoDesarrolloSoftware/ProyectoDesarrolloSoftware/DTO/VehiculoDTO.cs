using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoDesarrolloSoftware.DTO

{
    public class VehiculoDTO
    {
        public int Placa { get; set; }
        public string Modelo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]

        public DateTime Año { get; set; }
        public string Color { get; set; }
        public int Puestos { get; set; }
        public string SerialMotor { get; set; }
        public virtual MarcaDTO marca { get; set; }
    }
}
