using NUnit.Framework;
using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IPieza_ProveedorDAO
    {
        public List<Pieza_ProveedorDTO> GetListaPiezasDeProveedoresById(int Id_Proveedor);
        public Task Add(Pieza_ProveedorDTO pieza_proveedorDTO);
        public Task update(Pieza_ProveedorDTO pieza_proveedorDTO, int Id_Pieza, int Id_Proveedor);
        public Task delete(int Id_Pieza, int Id_Proveedor);
        public Pieza_ProveedorDTO GetPiezaDeProveedor(int Id_Pieza, int Id_Proveedor);
    }
}
