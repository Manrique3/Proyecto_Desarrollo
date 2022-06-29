using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("Cotizacion_proveedores")]
    [ApiController]
    public class Cotizacion_pController : ControllerBase
    {

        private readonly Icotizacion_proveedorDAO _Icotizacion_ProveedorDAO;
        private readonly ILogger<Cotizacion_pController> _logger;

        public Cotizacion_pController(ILogger<Cotizacion_pController> logger, Icotizacion_proveedorDAO icotizacion_ProveedorDAO)
        {
            _Icotizacion_ProveedorDAO = icotizacion_ProveedorDAO;
            _logger = logger;
        }

        [HttpGet("LitaCotizaciones_Proveedores")]
        public Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>> GetCotizacionesByProveedor()//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>>();


            response.Data = _Icotizacion_ProveedorDAO.GetListaCotizacionesDeProveedores();//(IDMarca, Id_Taller); 
            {
                response.Success = false;
            }
            return response;
        }

    }   
}
