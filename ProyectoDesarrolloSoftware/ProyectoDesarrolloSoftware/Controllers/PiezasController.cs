using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.Responses;
using static ProyectoDesarrolloSoftware.Responses.ResponsesProyecto;
using ProyectoDesarrolloSoftware.Exceptions;
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
        public ApplicationResponse<List<PiezaDTO>> GetPiezasById([Required][FromRoute] string Nombre)
        {
            var response = new ApplicationResponse<List<PiezaDTO>>();
            try
            {
                response.Data = _piezasDAO.GetListaPiezasByName(Nombre);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("ObtenerPieza/{Id_Pieza}")]
        public ApplicationResponse<PiezaDTO> GetPieza([Required][FromRoute] int Id_Pieza)
        {
            var response = new ApplicationResponse<PiezaDTO>();
            try
            {
                response.Data = _piezasDAO.GetPieza(Id_Pieza);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost("create")]
        public ActionResult CreatePieza(PiezaDTO piezaDTO)
        {

            _piezasDAO.Add(piezaDTO);

            return Ok();
        }

        [HttpPut("ActualizarPieza/{Id_Pieza}")]

        public ActionResult UpdatePieza(PiezaDTO piezaDTO, [Required][FromRoute] int Id_Pieza)
        {
            _piezasDAO.update(piezaDTO, Id_Pieza);
            return Ok();
        }

        [HttpDelete("BorrarPieza/{Id_Pieza}")]

        public ActionResult DeletePieza([Required][FromRoute] int Id_Pieza)
        {
            _piezasDAO.delete(Id_Pieza);
            return Ok();
        }

    }
}