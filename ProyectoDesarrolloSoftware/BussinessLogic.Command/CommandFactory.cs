using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Asegurados;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Piezas;
using ProyectoDesarrolloSoftware.Entidades;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command
{
    public class CommandFactory
    {
        public static VerRegistrosAseguradoCommand createVerRegistrosAseguradoCommand(string asegurado)
        {
            return new VerRegistrosAseguradoCommand(asegurado);
        }
        public static CrearRegistroAseguradoCommand crearCrearRegistroAseguradoCommand(Asegurado asegurado)
        {
            return new CrearRegistroAseguradoCommand(asegurado);
        }

        public static VerRegistrosPiezasCommand createVerRegistrosPiezasCommand(string Nombre)
        {
            return new VerRegistrosPiezasCommand(Nombre);
        }

    }
}
