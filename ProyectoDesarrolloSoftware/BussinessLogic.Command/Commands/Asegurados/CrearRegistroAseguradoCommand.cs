using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.Entidades;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Asegurados
{
    public class CrearRegistroAseguradoCommand : Command<AseguradoDTO>
    {
        private readonly Asegurado _asegurado;
        private AseguradoDTO _result;
        public CrearRegistroAseguradoCommand(Asegurado asegurado)
        {
            _asegurado = asegurado;
        }

        public override void Execute()
        {
            AseguradoDAO aseguradoDAO = AseguradoFabrica.CreateAseguradoDB();
      
            //_result = aseguradoDAO.CrearRegistroAsegurado(_asegurado);       
        }

        public override AseguradoDTO GetResult()
        {
            return _result;
        }


    }
}
