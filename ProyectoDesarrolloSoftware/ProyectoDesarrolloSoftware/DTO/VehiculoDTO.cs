using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoDesarrolloSoftware.DTO

{
    public class VehiculoDTO
    {
        private int Placa { get; set; }
        private string Modelo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy}", ApplyFormatInEditMode = true)]

        private DateTime Año { get; set; }
        private string Color { get; set; }
        private int Puestos { get; set; }
        private string SerialMotor { get; set; }
        public virtual MarcaDTO marca { get; set; }
    }
}
