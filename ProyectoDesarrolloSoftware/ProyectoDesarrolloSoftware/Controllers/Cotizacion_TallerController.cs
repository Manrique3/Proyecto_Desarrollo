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
    [Route("CotizacionesDeTalleres")]
    [ApiController]
    public class Cotizacion_TallerController : ControllerBase
    {
        private readonly ICotizacion_TallerDAO _cotizacionTallerDAO;
        private readonly ILogger<Cotizacion_TallerController> _logger;

        public Cotizacion_TallerController(ILogger<Cotizacion_TallerController> logger, ICotizacion_TallerDAO cotizacion_tallerDAO)
        {
            _cotizacionTallerDAO = cotizacion_tallerDAO;
            _logger = logger;
        }


        [HttpGet("ListaCotizacionesDeTalleres/{Id_Cotizacion}")]
        public ApplicationResponse<List<Cotizacion_TallerDTO>> GetListaCotizacionTallerById([Required][FromRoute] int Id_Cotizacion)
        {
            var response = new ApplicationResponse<List<Cotizacion_TallerDTO>>();
            try
            {
                response.Data = _cotizacionTallerDAO.GetListaCotizacionDeTallerById(Id_Cotizacion);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("ObtenerCotizacionDeTaller/{Id_Cotizacion}")]
        [Produces("application/json")]
        public Cotizacion_TallerDTO GetCotizacionTaller([Required][FromRoute] int Id_Cotizacion)
        {
            var obj = new Cotizacion_TallerDTO();

            obj = _cotizacionTallerDAO.GetCotizacionTaller(Id_Cotizacion);


            return obj;
        }

        [HttpPost("create/{Id_Cotizacion}/{Id_Taller}")]
        public ActionResult CreateCotizacionTaller(Cotizacion_TallerDTO cotizacion_tallerDTO, [Required][FromRoute] int Id_Cotizacion, [Required][FromRoute] int Id_Taller)
        {

            _cotizacionTallerDAO.Add(cotizacion_tallerDTO, Id_Cotizacion, Id_Taller);

            return Ok(cotizacion_tallerDTO);
        }

        [HttpPut("ActualizarCotizacion/{Id_Cotizacion}")]

        public ActionResult UpdateCotizacion(Cotizacion_TallerDTO cotizacion_tallerDTO, [Required][FromRoute] int Id_Cotizacion)
        {
            _cotizacionTallerDAO.update(cotizacion_tallerDTO, Id_Cotizacion);
            return Ok(cotizacion_tallerDTO);
        }

        [HttpDelete("BorrarCotizacionTaller/{Id_Cotizacion}")]

        public ActionResult DeleteCotizacionTaller([Required][FromRoute] int Id_Cotizacion)
        {
            _cotizacionTallerDAO.delete(Id_Cotizacion);
            return Ok();
        }
    }
}
