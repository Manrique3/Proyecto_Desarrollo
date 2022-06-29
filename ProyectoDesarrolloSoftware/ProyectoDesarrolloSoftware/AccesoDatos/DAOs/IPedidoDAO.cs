using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Exceptions;
using System.Threading.Tasks;
using ProyectoDesarrolloSoftware.Entidades;
namespace ProyectoDesarrolloSoftware.AccesoDatos.DAOs
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
