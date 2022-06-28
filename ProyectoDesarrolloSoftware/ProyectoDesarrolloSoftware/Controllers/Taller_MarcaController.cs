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
    [Route("TallerMarcas")]
    [ApiController]
    public class Taller_MarcaController : ControllerBase
    {
        private readonly ITaller_MarcaDAO _taller_MarcaDAO;
        private readonly ILogger<Taller_MarcaController> _logger;

        public Taller_MarcaController(ILogger<Taller_MarcaController> logger, ITaller_MarcaDAO taller_MarcaDAO)
        {
            _taller_MarcaDAO = taller_MarcaDAO;
            _logger = logger;
        }

        [HttpGet("LitaMarca_Taller")]
        public Responses.ApplicationResponse<List<Taller_MarcaDTO>> GetPiezasDeProveedorById ()//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Taller_MarcaDTO>>();


            response.Data = _taller_MarcaDAO.GetListaMarcaDeTallerById();//(IDMarca, Id_Taller);

            {
                response.Success = false;
            }
            return response;
        }
        [HttpGet("ListaTallerPorMarca/{Id_Taller}")]
        [Produces("application/json")]

        public Responses.ApplicationResponse<List<Taller_MarcaDTO>> GetTallerByMarca([Required][FromRoute] int Id_Taller)//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Taller_MarcaDTO>>();

            response.Data = _taller_MarcaDAO.GetMarcaDeTaller(Id_Taller);//(IDMarca, Id_Taller);

            {
                response.Success = false;
            }
            return response;

        }

        [HttpGet("ListaMarcaPorTaller/{IDMarca}")]
        [Produces("application/json")]

        public Responses.ApplicationResponse<List<Taller_MarcaDTO>> GetMarcaByTaller([Required][FromRoute] int IDMarca, int Id_Taller)//([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            var response = new Responses.ApplicationResponse<List<Taller_MarcaDTO>>();

            response.Data = _taller_MarcaDAO.GetTallerDeMarca(IDMarca);//(IDMarca, Id_Taller);

            {
                response.Success = false;
            }
            return response;

        }

        [HttpPost]
        [Route ("CrearTallerMarca")]
        public IActionResult CreatePiezaProveedor(Taller_MarcaDTO taller)
        {

            _taller_MarcaDAO.Add(taller);
            return Ok("Se ha creado con exito una marca para taller: " + taller.Nombre_Marca);

        }

       /* [HttpPut("ActualizarTallerMarca/{IDMarca}/{Id_Taller}")]
        public ActionResult UpdateTallerMarca(Taller_MarcaDTO taller_marcaDTO, [Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            _taller_MarcaDAO.update(taller_marcaDTO, IDMarca, Id_Taller);
            return Ok("Se actualizo con exito el taller" + taller_marcaDTO.Nombre_Marca);
        }*/

        [HttpDelete("BorrarTallerMarca/{IDMarca}/{Id_Taller}")]
        public ActionResult DeleteTallerMarca([Required][FromRoute] int IDMarca, [Required][FromRoute] int Id_Taller)
        {
            _taller_MarcaDAO.delete(IDMarca, Id_Taller);
            return Ok("Se elimino con exito el taller");
        }

    }
}
