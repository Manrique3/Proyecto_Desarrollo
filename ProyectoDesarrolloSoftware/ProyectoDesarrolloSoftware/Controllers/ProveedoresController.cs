using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("proveedores")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedoresDAO _proveedoresDAO;
        private readonly ILogger<ProveedoresController> _logger;

        public ProveedoresController(ILogger<ProveedoresController> logger, IProveedoresDAO proveedoresDAO)
        {
            _proveedoresDAO = proveedoresDAO;
            _logger = logger;
        }


        [HttpGet("ListaProveedores/{Nombre}")]
        public Responses.ApplicationResponse<List<ProveedorDTO>> GetProveedoresByName([Required][FromRoute] string Nombre)
        {
            var response = new Responses.ApplicationResponse<List<ProveedorDTO>>();


            response.Data = _proveedoresDAO.GetListaProveedoresByName(Nombre);

            {
                response.Success = false;
            }
            return response;
        }

        [HttpGet("ObtenerProveedor/{Id_Proveedor}")]
        [Produces("application/json")]
        public ProveedorDTO GetProveedor([Required][FromRoute] int Id_Proveedor)
        {
            var obj = new ProveedorDTO();

            obj = _proveedoresDAO.GetProveedor(Id_Proveedor);


            return obj;
        }

        [HttpPost("create")]
        public ActionResult CreateProveedor(ProveedorDTO proveedorDTO)
        {

            _proveedoresDAO.Add(proveedorDTO);

            return Ok(proveedorDTO);
        }       

        [HttpPut("ActualizarProveedor/{Id_Proveedor}")]

        public ActionResult UpdateProveedor(ProveedorDTO ProveedorDTO, [Required][FromRoute] int Id_Proveedor)
        {
            _proveedoresDAO.update(ProveedorDTO, Id_Proveedor);
            return Ok(ProveedorDTO);
        }

        [HttpDelete("BorrarProveedor/{Id_Proveedor}")]

        public ActionResult DeleteProveedor([Required][FromRoute] int Id_Proveedor)
        {
            _proveedoresDAO.delete(Id_Proveedor);
            return Ok();
        }
        
    }
}
