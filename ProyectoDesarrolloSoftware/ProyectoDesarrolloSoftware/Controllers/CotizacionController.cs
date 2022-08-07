using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;
namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("cotizaciones")]
    [ApiController]
    public class CotizacionController : ControllerBase
    {
        private readonly ICotizacionDAO _cotizacionDAO;
        private readonly ILogger<CotizacionController> _logger;

        public CotizacionController(ILogger<CotizacionController> logger, ICotizacionDAO cotizacionDAO)
        {
            _cotizacionDAO = cotizacionDAO;
            _logger = logger;
        }


        [HttpGet("ListaCotizaciones/{Id_Cotizacion}")]
        public ApplicationResponse<List<CotizacionDTO>> GetCotizacionById([Required][FromRoute] int Id_Cotizacion)
        {
            var response = new ApplicationResponse<List<CotizacionDTO>>();
            try
            {
                response.Data = _cotizacionDAO.GetListaCotizacionesById(Id_Cotizacion);
            }
            catch (Excepciones ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                response.Exception = ex.Excepcion.ToString();
            }
            return response;
        }

        [HttpGet("ObtenerCotizacion/{Id_Cotizacion}")]
        [Produces("application/json")]
        public CotizacionDTO GetCotizacion([Required][FromRoute] int Id_Cotizacion)
        {
            var obj = new CotizacionDTO();

            obj = _cotizacionDAO.GetCotizacion(Id_Cotizacion);


            return obj;
        }

        [HttpPost("create")]
        public ActionResult CreateCotizacion(CotizacionDTO cotizacionDTO)
        {

            _cotizacionDAO.Add(cotizacionDTO);

            return Ok(cotizacionDTO);
        }

        [HttpPut("ActualizarCotizacion/{Id_Cotizacion}")]

        public ActionResult UpdateCotizacion(CotizacionDTO cotizacionDTO, [Required][FromRoute] int Id_Cotizacion)
        {
            _cotizacionDAO.Update(cotizacionDTO, Id_Cotizacion);
            return Ok(cotizacionDTO);
        }

        [HttpDelete("BorrarCotizacion/{Id_Cotizacion}")]

        public ActionResult DeleteCotizacion([Required][FromRoute] int Id_Cotizacion)
        {
            _cotizacionDAO.Delete(Id_Cotizacion);
            return Ok();
        }
    }
}
