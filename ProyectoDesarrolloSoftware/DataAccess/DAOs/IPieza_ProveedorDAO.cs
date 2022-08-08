using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IPieza_ProveedorDAO
    {
        public Pieza_ProveedorDTO VerRegistrosPieza_Proveedor(int Id_Proveedor);
        public Task Add(Pieza_ProveedorDTO pieza_proveedorDTO);
        public Task update(Pieza_ProveedorDTO pieza_proveedorDTO, int Id_Pieza, int Id_Proveedor);
        public Task delete(int Id_Pieza, int Id_Proveedor);
        public Pieza_ProveedorDTO GetPiezaDeProveedor(int Id_Pieza, int Id_Proveedor);
    }
}
