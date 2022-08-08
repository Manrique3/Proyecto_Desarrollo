using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Taller_Marca
{
    public class VerRegistrosTallerMarcaCommand : Command<Taller_MarcaDTO>
    {
        private readonly int _TallerMarca;
        private Taller_MarcaDTO _result;

        public VerRegistrosTallerMarcaCommand(int TallerMarca)
        {
            _TallerMarca = TallerMarca;
        }
        public override void Execute()
        {
            Taller_MarcaDAO T_MarcaDAO = Taller_MarcaFactory.CreateTallerMarcasDB();

            //_result = T_MarcaDAO.GetMarcaDeTaller(_TallerMarca);
        }

        public override Taller_MarcaDTO GetResult()
        {
            return _result;
        }
    }
}
