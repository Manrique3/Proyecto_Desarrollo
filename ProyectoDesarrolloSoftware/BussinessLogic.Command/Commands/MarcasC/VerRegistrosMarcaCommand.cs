using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.MarcasC
{
    public class VerRegistrosMarcaCommand : Command<MarcaDTO>
    {
        private readonly int _marca;
        private MarcaDTO _result;

        public VerRegistrosMarcaCommand(int marca)
        {
            _marca = marca;
        }

        public override void Execute()
        {
            MarcaDAO marcaDAO = MarcaFactory.CreateMarcaDB();

            _result = marcaDAO.GetMarca(_marca);
        }

        public override MarcaDTO GetResult()
        {
            return _result;
        }
    }
}
