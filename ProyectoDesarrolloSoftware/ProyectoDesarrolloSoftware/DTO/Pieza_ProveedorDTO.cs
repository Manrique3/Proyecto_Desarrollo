﻿namespace ProyectoDesarrolloSoftware.DTO
{
    public class Pieza_ProveedorDTO
    {
        public int Id_Pieza { get; set; }
        public int Id_Proveedor { get; set; }
        public int cantidad { get; set; }
        public PiezaDTO Pieza { get; set; }
        public ProveedorDTO Proveedor { get; set; }

    }
}