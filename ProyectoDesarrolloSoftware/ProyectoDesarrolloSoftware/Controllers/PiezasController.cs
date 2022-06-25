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

        [HttpGet("pieza/{Id_Pieza}")]
        public ApplicationResponse<List<PiezaDTO>> GetPiezasById([Required][FromRoute] int Id_Pieza)
        {
            var response = new ApplicationResponse<List<PiezaDTO>>();
            try
            {
                response.Data = _piezasDAO.GetPiezasById(Id_Pieza);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }
    }
}