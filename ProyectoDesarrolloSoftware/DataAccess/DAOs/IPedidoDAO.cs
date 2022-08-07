using System.Collections.Generic;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;

namespace ProyectoDesarrolloSoftware.DataAccess.DAOs
{
    public interface IPedidoDAO
    {
        public List<PedidoDTO> GetListaPedidoById(int Id_Pedido);
        public Task Add(PedidoDTO pedidoDTO);
        public Task update(PedidoDTO pedidoDTO, int Id_Pedido);
        public Task delete(int Id_Pedido);
        public PedidoDTO GetPedido(int Id_Pedido);
    }
}
