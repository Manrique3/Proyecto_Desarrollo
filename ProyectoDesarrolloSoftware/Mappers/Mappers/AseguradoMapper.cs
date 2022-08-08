using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.Entidades;

namespace ProyectoDesarrolloSoftware.Mappers.Mappers
{
    public class AseguradoMapper
    {
        public static Asegurado MapDtoToEntity(AseguradoDTO dto)
        {
            var asegurado = new Asegurado
            {
                Cedula = dto.Cedula,
                Nombre = dto.Nombre,
                Apellido = dto.Apellido
            };
            return asegurado;
        }
    }
}
