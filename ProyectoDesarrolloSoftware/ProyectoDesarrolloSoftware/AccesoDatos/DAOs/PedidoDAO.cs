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
    public class PedidoDAO : IPedidoDAO
    {
        public readonly DSDBContext _context;

        public PedidoDAO(DSDBContext context)
        {
            _context = context;
        }

        public List<PedidoDTO> GetListaPedidoById(int pedido)
        {
            try
            {
                var query = _context.Pedidos
                   .Where(a => a.Id_Pedido == pedido)
                   .Select(a => new PedidoDTO
                   {
                       Id_Pedido = a.Id_Pedido,
                       estatus = a.estatus,
                       pago_total = a.pago_total,
                       numero_factura = a.numero_factura,
                        

                   });

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Excepciones("Ha ocurrido un error al intentar consultar la lista de pedidos" + pedido, ex.Message, ex);
            }

        }

        public Task Add(PedidoDTO pedidoDTO)
        {
            Pedido pedido = new Pedido();
            pedido.Id_Pedido = pedidoDTO.Id_Pedido;
            pedido.estatus = pedidoDTO.estatus;
            pedido.pago_total = pedidoDTO.pago_total;
            pedido.numero_factura = pedidoDTO.numero_factura;
            pedido.fk_proveedor_prov_cot = pedidoDTO.fk_proveedor_prov_cot;
            pedido.fk_cotizacion_prov_cot = pedidoDTO.fk_cotizacion_prov_cot;
            pedido.fk_taller_taller_cot = pedidoDTO.fk_taller_taller_cot;
            pedido.fk_cotizacion_taller_cot = pedidoDTO.fk_cotizacion_taller_cot;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task update(PedidoDTO pedidoDTO, int Id_Pedido)
        {
            var itemToUpdate = _context.Pedidos.Find(Id_Pedido);
            itemToUpdate.estatus = pedidoDTO.estatus;
            _context.SaveChanges();

            return Task.CompletedTask;
        }

        public Task delete(int Id_Pedido)
        {
            var ItemToRemove = _context.Pedidos.Find(Id_Pedido);
            _context.Pedidos.Remove(ItemToRemove);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public PedidoDTO GetPedido(int Id_Pedido)
        {
            var query = _context.Pedidos
                .Where(a => a.Id_Pedido == Id_Pedido)
                .Select(a => new PedidoDTO
                {
                    Id_Pedido = a.Id_Pedido,
                    estatus = a.estatus,
                    pago_total = a.pago_total,
                    numero_factura = a.numero_factura,
                    


                });
            return query.First();
        }
    }
}

