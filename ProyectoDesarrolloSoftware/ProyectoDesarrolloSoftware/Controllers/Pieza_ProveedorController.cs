using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.BussinessLogic.Command;
using ProyectoDesarrolloSoftware.BussinessLogic.Command.Commands.Pieza_Proveedores;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;
using ProyectoDesarrolloSoftware.Exceptions;

namespace ProyectoDesarrolloSoftware.Controllers
{
    [Route("PiezasProveedores")]
    [ApiController]
    public class Pieza_ProveedorController : ControllerBase
    {
        private readonly IPieza_ProveedorDAO _pieza_proveedorDAO;
        private readonly ILogger<Pieza_ProveedorController> _logger;

        public Pieza_ProveedorController(ILogger<Pieza_ProveedorController> logger, IPieza_ProveedorDAO pieza_proveedorDAO)
        {
            _pieza_proveedorDAO = pieza_proveedorDAO;
            _logger = logger;
        }


        [HttpGet("ListaPieza_Proveedor/{Id_Proveedor}")]
        public Pieza_ProveedorDTO VerRegistrosPieza_Proveedor([Required][FromRoute] int Id_Proveedor)
        {
            //var response = new Responses.ApplicationResponse<List<Pieza_ProveedorDTO>>();

            try
            {
                VerRegistrosPieza_ProveedoresCommand command =
                    CommandFactory.createVerRegistrosPieza_ProveedoresCommand(Id_Proveedor);
                command.Execute();
                return command.GetResult();
            }
            catch (Excepciones ex)
            {
                throw;
               // response.Data = _pieza_proveedorDAO.GetListaPiezasDeProveedoresById(Id_Proveedor);

            
             //   response.Success = false;
            }
            //return response;
        }

        [HttpGet("ObtenerPieza/{Id_Pieza}/{Id_Proveedor})")]
        [Produces("application/json")]
        public Pieza_ProveedorDTO GetPiezaDeProveedor([Required][FromRoute] int Id_Pieza, [Required][FromRoute] int Id_Proveedor)
        {
            var obj = new Pieza_ProveedorDTO();

            obj = _pieza_proveedorDAO.GetPiezaDeProveedor(Id_Pieza, Id_Proveedor);


            return obj;
        }

        [HttpPost("create")]
        public ActionResult CreatePiezaProveedor(Pieza_ProveedorDTO pieza_proveedorDTO)
        {

            _pieza_proveedorDAO.Add(pieza_proveedorDTO);

            return Ok(pieza_proveedorDTO);
        }

        [HttpPut("ActualizarPiezaProveedor/{Id_Pieza}/{Id_proveedor}")]

        public ActionResult UpdatePieza(Pieza_ProveedorDTO pieza_proveedorDTO, [Required][FromRoute] int Id_Pieza, [Required][FromRoute] int Id_Proveedor)
        {
            _pieza_proveedorDAO.update(pieza_proveedorDTO, Id_Pieza,Id_Proveedor);
            return Ok(pieza_proveedorDTO);
        }

        [HttpDelete("BorrarPiezaProveedor/{Id_Pieza}/{Id_Proveedor}")]

        public ActionResult DeletePiezaProveedor([Required][FromRoute] int Id_Pieza, [Required][FromRoute] int Id_Proveedor)
        {
            _pieza_proveedorDAO.delete(Id_Pieza, Id_Proveedor);
            return Ok();
        }
    }
}
