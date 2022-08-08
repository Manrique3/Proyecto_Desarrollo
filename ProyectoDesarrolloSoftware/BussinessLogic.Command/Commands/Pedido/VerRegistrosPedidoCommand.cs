using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.DataAccess.Fabricas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Pedido
{
    public class VerRegistrosPedidoCommand : Command<PedidoDTO>
    {
        private readonly int _pedido;
        private PedidoDTO _result;

        public VerRegistrosPedidoCommand(int pedido)
        {
            _pedido = pedido;
        }
        public override void Execute()
        {
            PedidoDAO pedidoDAO = PedidoFactory.CreatePedidoDB();
            _result = pedidoDAO.GetPedido(_pedido);
        }

        public override PedidoDTO GetResult()
        {
            return _result;
        }
    }
}
