using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoDesarrolloSoftware.Entidades
{
    public class Proveedor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_proveedor { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int fk_lugar { get; set; }
        [ForeignKey("fk_lugar")]
        public virtual Lugar Lugar { get; set; }
        public virtual ICollection<Marca> Marcas { get; set; }

        public virtual ICollection<Pieza> Piezas { get; set; } //Muchas Piezas para la tabla Pieza_Proveedor
        public virtual ICollection<Cotizacion>Cotizacions { get; set; } //Muchas Cotizaciones para la tabla Cotizacion_Proveedor
    }
}
