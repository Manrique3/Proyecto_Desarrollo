using System.Collections.Generic;

namespace ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO
{
    public class LugarDTO
    {
        public int Id_lugar { get; set; }
        public string nombre_lugar { get; set; }
        public string tipo_lugar { get; set; }

        public List <LugarDTO> lugares {get; set; }
    }
}
