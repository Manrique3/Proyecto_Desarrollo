using System.Collections.Generic;

namespace ProyectoDesarrolloSoftware.DTO
{
    public class LugarDTO
    {
        private int Id_lugar { get; set; } 
        private string nombre_lugar { get; set; }
        private string tipo_lugar { get; set; }

        public List <LugarDTO> lugares {get; set; }
    }
}
