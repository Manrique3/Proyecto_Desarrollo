using NUnit.Framework;
using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IProveedoresDAO
    {
        public List<ProveedorDTO> GetListaProveedoresByName(string Nombre);
        public Task Add(ProveedorDTO proveedorDTO);
        public Task update(ProveedorDTO proveedorDTO, int Id_Proveedor);
        public Task delete(int Id_Proveedor);
        public ProveedorDTO GetProveedor(int Id_Proveedor);

    }
}
