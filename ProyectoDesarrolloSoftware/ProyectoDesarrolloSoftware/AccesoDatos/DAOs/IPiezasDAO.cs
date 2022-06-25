using NUnit.Framework;
using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IPiezasDAO
    {
        public List<PiezaDTO> GetPiezasById(int Id_Pieza);
    }
}
