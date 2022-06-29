using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
{
    public interface ITaller_MarcaDAO
    {
        public List<Taller_MarcaDTO> GetListaMarcaDeTallerById();//(int IDMarca, int Id_Taller);
        public Task Add(Taller_MarcaDTO taller_MarcaDTO);

        ///public Task update(Taller_MarcaDTO taller_MarcaDTO, int IDMarca, int Id_Taller);
        public Task delete(int IDMarca, int Id_Taller);
        public List<Taller_MarcaDTO> GetMarcaDeTaller(int Id_Taller);
        public List<Taller_MarcaDTO> GetTallerDeMarca(int IDMarca);
    }
}
