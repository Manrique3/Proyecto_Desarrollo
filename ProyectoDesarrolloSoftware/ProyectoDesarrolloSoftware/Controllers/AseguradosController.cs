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
    [Route("asegurado")]
    [ApiController]
    public class AseguradosController : ControllerBase
    {
        private readonly AseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradosController> _logger;

        public AseguradosController(ILogger<AseguradosController> logger, AseguradoDAO aseguradoDAO)
            {
            _aseguradoDAO = aseguradoDAO;
            _logger = logger;
            }

        [HttpGet("asegurados/{asegurado}")]
        public ApplicationResponse<List<AseguradoDTO>> VerRegistrosAsegurado([Required][FromRoute] string asegurado)
        {
            var response = new ApplicationResponse<List<AseguradoDTO>>();
            try
            {
                response.Data = _aseguradoDAO.VerRegistrosAsegurado(asegurado);   
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("aseguradoregistrado/{cedula}")]
        public ApplicationResponse<AseguradoDTO> GetAsegurado([Required][FromRoute] int cedula)
        {
            var response = new ApplicationResponse<AseguradoDTO>();
            try
            {
                response.Data = _aseguradoDAO.GetAsegurado(cedula);
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
        public ActionResult RegistrarAsegurado(AseguradoDTO aseguradoDTO)
        {
            _aseguradoDAO.Add(aseguradoDTO);
            return Ok();
        }

        [HttpPut("Actualizar/{Cedula}")]
        public ActionResult UpdateAsegurado(AseguradoDTO aseguradoDTO, [Required][FromRoute] int Cedula)
        {
            _aseguradoDAO.update(aseguradoDTO, Cedula);
            return Ok();
        }

        [HttpDelete("BorrarAsegurado/{Cedula}")]

        public ActionResult DeleteAsegurado([Required][FromRoute] int Cedula)
        {
            _aseguradoDAO.Delete(Cedula);
            return Ok();
        }

    }
}
