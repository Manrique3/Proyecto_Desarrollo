using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.BussinessLogic.Command;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Piezas;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;
namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("piezas")]
    [ApiController]
    public class PiezasController : ControllerBase
    {
        private readonly IPiezasDAO _piezasDAO;
        private readonly ILogger<PiezasController> _logger;

        public PiezasController(ILogger<PiezasController> logger, IPiezasDAO piezasDAO)
        {
            _piezasDAO = piezasDAO;
            _logger = logger;
        }
        

        [HttpGet("Listapiezas/{Nombre}")]
        public PiezaDTO VerRegistrosPieza([Required][FromRoute] string Nombre)
        {
            //var response = new ApplicationResponse<List<PiezaDTO>>();
            try
            {
                VerRegistrosPiezasCommand command =
                    CommandFactory.createVerRegistrosPiezasCommand(Nombre);
                command.Execute();
                return command.GetResult();
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

        [HttpGet("ObtenerPieza/{Id_Pieza}")]
        [Produces("application/json")]
        public PiezaDTO GetPieza([Required][FromRoute] int Id_Pieza)
        {
            var obj = new PiezaDTO();
            
                obj = (PiezaDTO)_piezasDAO.GetPieza(Id_Pieza);
            
            
            return obj;
        }

        [HttpPost("create")]
        public ActionResult CreatePieza(PiezaDTO piezaDTO)
        {

            _piezasDAO.Add(piezaDTO);

            return Ok(piezaDTO);
        }

        [HttpPut("ActualizarPieza/{Id_Pieza}")]

        public ActionResult UpdatePieza(PiezaDTO piezaDTO, [Required][FromRoute] int Id_Pieza)
        {
            _piezasDAO.update(piezaDTO, Id_Pieza);
            return Ok(piezaDTO);
        }

        [HttpDelete("BorrarPieza/{Id_Pieza}")]

        public ActionResult DeletePieza([Required][FromRoute] int Id_Pieza)
        {
            _piezasDAO.delete(Id_Pieza);
            return Ok();
        }

    }
}