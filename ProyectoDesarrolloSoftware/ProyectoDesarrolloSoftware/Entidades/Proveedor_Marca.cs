using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Proveedor_Marca
    {

        [Key,Column(Order = 1)]
        public int IDMarca { get; set; }

        [Key,Column(Order = 2)]
        public int Id_proveedor { get; set; }

        [ForeignKey("IDMarca")]
        public Marca Marca { get; set; }

        [ForeignKey("Id_proveedor")]
        public Proveedor Proveedor { get; set; }
    }
}
