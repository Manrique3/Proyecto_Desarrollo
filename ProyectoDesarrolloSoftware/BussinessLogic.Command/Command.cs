using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProyectoDesarrolloSoftware.BussinessLogic.Command
{
    public abstract class Command<Tout> : ICommand<Tout>
    {
        public abstract void Execute();
        public abstract Tout GetResult();
    }
}
