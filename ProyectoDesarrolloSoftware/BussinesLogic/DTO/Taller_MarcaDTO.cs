namespace ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO
{
    public class Taller_MarcaDTO
    {
        public int IDMarca { get; set; }
        public int Id_Taller { get; set; }
        public string Nombre_Taller { get;  set; } // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set
        public string Nombre_Marca { get;  set; } // Deberia ir {get; internal set;} Daba error en el DAO por no tener acceso al set

    }
}
