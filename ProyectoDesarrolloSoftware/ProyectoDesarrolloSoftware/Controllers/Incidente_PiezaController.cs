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
    [Route("incidente_pieza")]
    [ApiController]
    public class Incidente_PiezaController : ControllerBase
    {
        private readonly IIncidente_PiezaDAO _incidente_piezaDAO;
        private readonly ILogger<Incidente_PiezaController> _logger;

        public Incidente_PiezaController(ILogger<Incidente_PiezaController> logger, IIncidente_PiezaDAO incidente_piezaDAO)
        {
            _incidente_piezaDAO = incidente_piezaDAO;
            _logger = logger;
        }

        [HttpGet("lista/{Id_Incidente}")]
        public ApplicationResponse<List<Incidente_PiezaDTO>> GetIncidente_Pieza([Required][FromRoute] int Id_Incidente)
        {
            var response = new ApplicationResponse<List<Incidente_PiezaDTO>>();
            try
            {
                response.Data = _incidente_piezaDAO.GetIncidente_Pieza(Id_Incidente);
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
        public ActionResult RegistrarIncidente_Pieza(Incidente_PiezaDTO incidente_piezaDTO)
        {
            _incidente_piezaDAO.Add(incidente_piezaDTO);
            return Ok("Se Agregó: " + incidente_piezaDTO.Id_Pieza + "," + incidente_piezaDTO.Id_Incidente);
        }

        [HttpDelete("borrar/{Id_Pieza}/{Id_Incidente}")]
        public ActionResult DeleteAsegurado([Required][FromRoute] int Id_Pieza, [Required][FromRoute] int Id_Incidente)
        {
            _incidente_piezaDAO.Delete(Id_Pieza, Id_Incidente);
            return Ok("Se Elimino con Exito");
        }


    }
}
