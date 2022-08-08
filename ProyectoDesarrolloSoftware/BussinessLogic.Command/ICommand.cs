using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command
{
    internal interface ICommand <TOut>
    {
            void Execute();
            TOut GetResult();
    }
}
