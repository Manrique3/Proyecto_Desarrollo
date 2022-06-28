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
    [Route("poliza")]
    [ApiController]
    public class PolizasController : ControllerBase
    {
        private readonly IPolizaDAO _polizaDAO;
        private readonly ILogger<PolizasController> _logger;

        public PolizasController(ILogger<PolizasController> logger, IPolizaDAO polizaDAO)
        {
            _polizaDAO = polizaDAO;
            _logger = logger;
        }

        [HttpGet("polizagenerada/{id_poliza}")]
        public ApplicationResponse<PolizaDTO> GetPoliza([Required][FromRoute] int id_poliza)
        {
            var response = new ApplicationResponse<PolizaDTO>();
            try
            {
                response.Data = _polizaDAO.GetPoliza(id_poliza);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost("registrarvehiculo")]
        public ActionResult Registrarvehiculo(VehiculoDTO vehiculoDTO)
        {
            _polizaDAO.AddVehiculo(vehiculoDTO);
            return Ok("Se registro un vehiculo: " + vehiculoDTO.Modelo);
        }
        
        [HttpPost("generarpoliza")]
        public ActionResult GenerarPoliza(PolizaDTO polizaDTO)
        {
            _polizaDAO.AddPoliza(polizaDTO);
            return Ok("Se registro una poliza de tipo: " + polizaDTO.Tipo);
        }

        [HttpPut("cambiartipo/{Id_Poliza}")]
        public ActionResult UpdateTipoPoliza(PolizaDTO polizaDTO, [Required][FromRoute] int Id_Poliza)
        {
            _polizaDAO.updateTipo(polizaDTO, Id_Poliza);
            return Ok("Se cambio el tipo de poliza a : " + polizaDTO.Tipo);
        }

        [HttpDelete("BorrarPoliza/{Id_Poliza}")]
        public ActionResult DeletePoliza([Required][FromRoute] int Id_Poliza)
        {
            _polizaDAO.Delete(Id_Poliza);
            return Ok("Se Elimino la Poliza con Exito");
        }
    }
}
