using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//FALTA POR TERMINAR CONTROLADOR




namespace ProyectoDesarrolloSoftware.Controllers
{
    
    [ApiController]
    public class TallerController : ControllerBase
    {
        private ITallerDAO _taller;
        private readonly ILogger<TallerController> _logger;

        public TallerController(ILogger<TallerController> logger, ITallerDAO italler)
        {
            _taller = italler;
            _logger = logger;
        }

        [HttpGet]
        [Route("api/[controller]/Lista")]
        public IActionResult GetTalleres()
        {
            return Ok(_taller.GetTalleres());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetTaller(int id)
        {
            var taller = _taller.GetTaller(id);

            if (taller != null)
            {
                return Ok(taller);
            }

            return NotFound($"error al buscar la marca con el id: {id} ");

        }
        [HttpPost]
        [Route("api/[controller]/AgregarTaller")] // Ruta en la que se agrega una marca dependiendo de id
        public IActionResult AgregarTaller(TallerDTO taller)
        {
            _taller.AddTaller(taller);
            return Ok("Se Agregó el taller: " + taller.Nombre);

            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + marca.IDMarca, marca);

        }
        [HttpDelete]
        [Route("api/[controller]/EliminarTaller/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult DeleteTaller(int id) // Se eliminar por ID y no por Objeto de Marca.
        {
            var taller = _taller.GetTaller(id);

            if (taller != null)
            {
                _taller.DeleteTaller(id);
                return Ok("Se eliminó el taller");
            }

            return NotFound($"error al buscar el taller con el id: {id} ");
        }

        [HttpPatch]
        [Route("api/[controller]/EditarTaller{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult EditTaller(TallerDTO tallerDTO, int id)
        {
            var ExisteTaller = _taller.GetTaller(id);

            if (ExisteTaller != null)
            {
                tallerDTO.Id_Taller = ExisteTaller.Id_Taller;
                tallerDTO.Nombre = ExisteTaller.Nombre;
                _taller.UpdateTaller(tallerDTO, id);

            }

            return Ok("Se cambio el taller: " + tallerDTO.Nombre + " a nombre de taller" + _taller);

        }

    }
}
