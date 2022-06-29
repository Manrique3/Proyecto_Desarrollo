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
    [Route("marca_proveedor")]
    [ApiController]
    public class Proveedor_MarcaController : ControllerBase
    {
        private readonly IProveedor_MarcaDAO _proveedor_marcaDAO;
        private readonly ILogger<Proveedor_MarcaController> _logger;

        public Proveedor_MarcaController(ILogger<Proveedor_MarcaController> logger, IProveedor_MarcaDAO proveedor_marcaDAO)
        {
            _proveedor_marcaDAO = proveedor_marcaDAO;
            _logger = logger;
        }

        [HttpGet("lista/{Id_Proveedor}")]
        public ApplicationResponse<List<Proveedor_MarcaDTO>> GetMarcaProveedor([Required][FromRoute] int Id_Proveedor)
        {
            var response = new ApplicationResponse<List<Proveedor_MarcaDTO>>();
            try
            {
                response.Data = _proveedor_marcaDAO.GetMarcaProveedor(Id_Proveedor);
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
        public ActionResult RegistrarIncidente_Pieza(Proveedor_MarcaDTO proveedor_marcaDTO)
        {
            _proveedor_marcaDAO.Add(proveedor_marcaDTO);
            return Ok("Se Agregó: " + proveedor_marcaDTO.Id_proveedor + "," + proveedor_marcaDTO.IDMarca);
        }

        [HttpDelete("borrar/{Id_Marca}/{Id_Proveedor}")]
        public ActionResult DeleteAsegurado([Required][FromRoute] int Id_Marca, [Required][FromRoute] int Id_Proveedor)
        {
            _proveedor_marcaDAO.Delete(Id_Marca, Id_Proveedor);
            return Ok("Se Elimino con Exito");
        }
    }
}
