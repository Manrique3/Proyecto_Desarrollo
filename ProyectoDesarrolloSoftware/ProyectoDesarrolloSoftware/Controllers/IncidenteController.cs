using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("incidente")]
    [ApiController]
    public class IncidenteController : ControllerBase
    {

        private readonly IIncidenteDAO _incidenteDAO;
        private readonly ILogger<IncidenteController> _logger;

        public IncidenteController(ILogger<IncidenteController> logger, IIncidenteDAO incidenteDAO)
        {
            _incidenteDAO = incidenteDAO;
            _logger = logger;
        }


        [HttpGet("incidenteregistrado/{Id_Incidente}")]
        public ApplicationResponse<IncidenteDTO> Getincidente([Required][FromRoute] int Id_Incidente)
        {
            var response = new ApplicationResponse<IncidenteDTO>();
            try
            {
                response.Data = _incidenteDAO.GetIncidente(Id_Incidente);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpPost("vehiculotercero")]
        public ActionResult Registrarvehiculo(VehiculoDTO vehiculoDTO)
        {
            _incidenteDAO.AddVehiculoTercaro(vehiculoDTO);
            return Ok("Se registro un vehiculo: " + vehiculoDTO.Modelo);
        }

        [HttpPost("registrar")]
        public ActionResult Registrarincidente(IncidenteDTO incidenteDTO)
        {
            _incidenteDAO.Add(incidenteDTO);
            return Ok("Se Agregó el estado del vehiculo: " + incidenteDTO.estadoEv);
        }

        [HttpPut("Actualizar/{Id_Incidente}")]
        public ActionResult Updateincidente(IncidenteDTO incidenteDTO, [Required][FromRoute] int Id_Incidente)
        {
            _incidenteDAO.update(incidenteDTO, Id_Incidente);
            return Ok("Se Actulizaron los datos del incidente: " + incidenteDTO.estadoEv);
        }

        [HttpDelete("Borrarincidente/{Id_Incidente}")]

        public ActionResult Deleteincidente([Required][FromRoute] int Id_Incidente)
        {
            _incidenteDAO.Delete(Id_Incidente);
            return Ok("Se Elimino el incidente con Exito");
        }

    }
}

