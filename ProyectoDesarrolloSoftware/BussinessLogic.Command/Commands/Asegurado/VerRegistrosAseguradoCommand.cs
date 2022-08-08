using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;


namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Asegurado
{

    public class VerRegistrosAseguradoCommand : Command<AseguradoDTO>
    {
        private readonly string _asegurado;
        private AseguradoDTO _result;

        public VerRegistrosAseguradoCommand(string asegurado)
        {
            _asegurado = asegurado;
        }

        public override void Execute()
        {
            AseguradoDAO aseguradoDAO = AseguradoFabrica.CreateAseguradoDB();  

            _result = aseguradoDAO.VerRegistrosAsegurado(_asegurado);
        }

        public override AseguradoDTO GetResult()
        {
            return _result;
        }

    }

}
