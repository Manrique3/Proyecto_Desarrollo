using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Talleres
{
    public class VerRegistroTallerCommand : Command<TallerDTO>
    {
        private readonly string _taller;
        private TallerDTO _result;
        public VerRegistroTallerCommand(string taller)
        {
            _taller = taller;
        }

        public override void Execute()
        {
            TallerDAO tallerDAO = TallerFactory.CreateProviderDB();

            _result = tallerDAO.VerRegistrosTaller(_taller);
        }

        public override TallerDTO GetResult()
        {
            return _result;
        }
    }
}
