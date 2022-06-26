using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.DataBase
{
    public interface IMarcaDAO
    {
        List<MarcaDTO>GetMarcas();

        MarcaDTO GetMarca(int Id);

        MarcaDTO AddMarca(MarcaDTO marca);

        void DeleteMarca(MarcaDTO marca);

        MarcaDTO EditMarca(MarcaDTO marca);


    }
}
