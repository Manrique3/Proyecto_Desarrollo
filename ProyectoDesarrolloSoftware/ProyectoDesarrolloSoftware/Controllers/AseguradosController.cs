using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Asegurados;
using ProyectoDesarrolloSoftware.BussinessLogic.Command;
using ProyectoDesarrolloSoftware.Mappers.Mappers;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("asegurado")]
    [ApiController]
    public class AseguradosController : ControllerBase
    {
        private readonly IAseguradoDAO _aseguradoDAO;
        private readonly ILogger<AseguradosController> _logger;

        public AseguradosController(ILogger<AseguradosController> logger, IAseguradoDAO aseguradoDAO)
            {
            _aseguradoDAO = aseguradoDAO;
            _logger = logger;
            }

        [HttpGet("asegurados/{asegurado}")]
        public AseguradoDTO VerRegistrosAsegurado([Required][FromRoute] string asegurado)
        {
            //var response = new ApplicationResponse<List<AseguradoDTO>>();
            try
            {
                VerRegistrosAseguradoCommand command =
                    CommandFactory.createVerRegistrosAseguradoCommand(asegurado);
                command.Execute();
                return command.GetResult();
                //response.Data = _aseguradoDAO.VerRegistrosAsegurado(asegurado);   
            }
            catch (Excepciones ex)
            {
                throw;
                //response.Success = false;
                //response.Message = ex.Message;
                //response.Exception = ex.Excepcion.ToString();
            }
            //return response;
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
            return Ok("Se Agregó el asegurado: " + aseguradoDTO.Nombre);
        }

        [HttpPut("Actualizar/{Cedula}")]
        public ActionResult UpdateAsegurado(AseguradoDTO aseguradoDTO, [Required][FromRoute] int Cedula)
        {
            _aseguradoDAO.update(aseguradoDTO, Cedula);
            return Ok("Se Actulizaron los datos del asegurado/a: " + aseguradoDTO.Nombre);
        }

        [HttpDelete("BorrarAsegurado/{Cedula}")]

        public ActionResult DeleteAsegurado([Required][FromRoute] int Cedula)
        {
            _aseguradoDAO.Delete(Cedula);
            return Ok("Se Elimino el Asegurado con Exito");
        }

    }
}
