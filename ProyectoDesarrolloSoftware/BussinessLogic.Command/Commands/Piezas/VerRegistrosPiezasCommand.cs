using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Piezas
{
    public class VerRegistrosPiezasCommand : Command<PiezaDTO>
    {

        private readonly string _pieza;
        private PiezaDTO _result;

        public VerRegistrosPiezasCommand(string pieza)
        {
            _pieza = pieza;
        }

        public override void Execute()
        {
            PiezasDAO piezaDAO = PiezaFactory.CreatePiezaDB();

            _result = piezaDAO.VerRegistrosPieza(_pieza);
        }

        public override PiezaDTO GetResult()
        {
            return _result;
        }

    }


}

