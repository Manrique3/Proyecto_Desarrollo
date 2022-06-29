using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("pedido")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoDAO _pedidoDAO;
        private readonly ILogger<PedidoController> _logger;

        public PedidoController(ILogger<PedidoController> logger, IPedidoDAO pedidoDAO)
        {
            _pedidoDAO = pedidoDAO;
            _logger = logger;
        }

        [HttpGet("pedido/{pedido}")]
        public ApplicationResponse<List<PedidoDTO>> GetListaPedidoById([Required][FromRoute] int pedido)
        {
            var response = new ApplicationResponse<List<PedidoDTO>>();
            try
            {
                response.Data = _pedidoDAO.GetListaPedidoById(pedido);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("pedidoregistrado/{Id_Pedido}")]
        public ApplicationResponse<PedidoDTO> GetPedido([Required][FromRoute] int Id_Pedido)
        {
            var response = new ApplicationResponse<PedidoDTO>();
            try
            {
                response.Data = _pedidoDAO.GetPedido(Id_Pedido);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost("registrar")]
        public ActionResult RegistrarPedido(PedidoDTO pedidoDTO)
        {
            _pedidoDAO.Add(pedidoDTO);
            return Ok("Se Agregó el pedido con el numero de factura: " + pedidoDTO.numero_factura);
        }

        [HttpPut("Actualizar/{Id_Pedido}")]
        public ActionResult UpdatePedido(PedidoDTO pedidoDTO, [Required][FromRoute] int Id_Pedido)
        {
            _pedidoDAO.update(pedidoDTO, Id_Pedido);
            return Ok("Se Actulizo el estado del pedido: " + pedidoDTO.estatus);
        }

        [HttpDelete("BorrarPedido/{Id_Pedido}")]

        public ActionResult DeletePedido([Required][FromRoute] int Id_Pedido)
        {
            _pedidoDAO.delete(Id_Pedido);
            return Ok("Se Elimino el Asegurado con Exito");
        }

    }
}

