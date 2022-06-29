using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("Cotizacion Proveedor")]
    [ApiController]
    public class Cotizacion_ProveedorController : ControllerBase
    {
        private readonly ICotizacion_ProveedorDAO _Cotizacion_Proveedor;
        private readonly ILogger<Cotizacion_ProveedorController> _logger;
        public Cotizacion_ProveedorController(ILogger<Cotizacion_ProveedorController> logger, ICotizacion_ProveedorDAO cotizacion_proveedor)
        {
            _Cotizacion_Proveedor = cotizacion_proveedor;
            _logger = logger;

        }

        [HttpGet("ListaCotizacion_Proveedor/{Id_Proveedor}")]
        public Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>> GetCotizacionesByProveedores(int Id_Proveedor)//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>>();

            response.Data = _Cotizacion_Proveedor.GetCotizacionesPorProveedor(Id_Proveedor);//(IDMarca, Id_Taller);

            {
                response.Success = false;
            }
            return response;
        }

        [HttpGet("ListaProveedor_Cotizacion/{Id_Cotizacion}")]
        public Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>> GetProveedoresByCotizaciones(int Id_Cotizacion)//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Cotizacion_proveedorDTO>>();

            response.Data = _Cotizacion_Proveedor.GetProveedoresPorCotizaciones(Id_Cotizacion);//(IDMarca, Id_Taller);

            {
                response.Success = false;
            }
            return response;
        }

        [HttpPost]
        [Route("CrearCotizacionProveedor")]
        public IActionResult CreatePiezaProveedor(Cotizacion_proveedorDTO cotizacion_Proveedor, int Id_Cotizacion, int Id_Proveedor)        {

            _Cotizacion_Proveedor.AddCotizacion_Proveedor(cotizacion_Proveedor,Id_Cotizacion, Id_Proveedor);
            return Ok("Se ha creado con exito la cotizacion");

        }

        [HttpPut("ActualizarCotizacionProveedor/{Id_Cotizacion}/{Id_Proveedor}")]
        public ActionResult EditarCotizacion_Proveedor(Cotizacion_proveedorDTO cotizacion_proveedorDTO, [Required][FromRoute] int Id_Cotizacion, [Required][FromRoute] int Id_Proveedor)
        {
            _Cotizacion_Proveedor.EditCotizacion_Proveedor(cotizacion_proveedorDTO, Id_Cotizacion, Id_Proveedor);
            return Ok("Se actualizo con exito la cotizacion del proveedor");
        }

        [HttpDelete("BorrarCotizacionProveedor/{Id_Cotizacion}/{Id_Proveedor}")]
        public ActionResult DeleteTallerMarca([Required][FromRoute] int Id_Cotizacion, [Required][FromRoute] int Id_Proveedor)
        {
            _Cotizacion_Proveedor.DeleteCotizacion_Proveedor(Id_Cotizacion, Id_Proveedor);
            return Ok("Se elimino con exito la cotizacion del proveedor");
        }

    }
}
