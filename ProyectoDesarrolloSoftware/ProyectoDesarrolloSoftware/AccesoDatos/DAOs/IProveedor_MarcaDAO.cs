using ProyectoDesarrolloSoftware.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface IProveedor_MarcaDAO
    {
        public Task Add(Proveedor_MarcaDTO proveedor_marcaDTO);
        public Task Delete(int Id_Marca, int Id_Proveedor);
        public List<Proveedor_MarcaDTO> GetMarcaProveedor(int Id_Proveedor);
    }
}
