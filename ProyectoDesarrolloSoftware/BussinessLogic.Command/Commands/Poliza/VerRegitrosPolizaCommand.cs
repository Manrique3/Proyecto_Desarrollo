using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Poliza
{
    public class VerRegitrosPolizaCommand : Command<PolizaDTO>
    {
        private readonly int _poliza;
        private PolizaDTO _result;

        public VerRegitrosPolizaCommand(int poliza)
        {
            _poliza = poliza;
        }

        public override void Execute()
        {
            PolizaDAO polizaDAO = PolizaFactory.CreatePolizaDB();
            _result = polizaDAO.GetPoliza(_poliza);
        }

        public override PolizaDTO GetResult()
        {
            return _result;
        }

    }
}
