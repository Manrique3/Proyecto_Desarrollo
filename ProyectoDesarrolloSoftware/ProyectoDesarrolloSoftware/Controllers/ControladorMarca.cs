using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProyectoDesarrolloSoftware.BussinesLogic.DTO.DTO;
using ProyectoDesarrolloSoftware.DataAccess.DAOs;

namespace ProyectoDesarrolloSoftware.Controllers
{

    [ApiController]
    public class ControladorMarca : ControllerBase
    {
        private IMarcaDAO _marca;
        private readonly ILogger<ControladorMarca> _logger;
        public ControladorMarca(ILogger<ControladorMarca> logger, IMarcaDAO marca)
        {
            _marca = marca;
            _logger = logger;

        }

        [HttpGet]
        [Route("api/[controller]")] // Ruta en la que se muestra la lista de marcas
        public IActionResult GetMarcas()
        {
            return Ok(_marca.GetMarcas()); //Deevulve la lista de Marcas Completas
        }

        [HttpGet]
        [Route("api/[controller]/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult GetMarca(int id)
        {
            var marca = _marca.GetMarca(id);

            if(marca != null)
            {
                return Ok(marca);
            }

            return NotFound($"error al buscar la marca con el id: {id} ");

        }

        [HttpPost]
        [Route("api/[controller]")] // Ruta en la que se agrega una marca dependiendo de id
        public IActionResult GetMarca(MarcaDTO marca)
        {
             _marca.AddMarca(marca);
            return Ok("Se Agregó la marca: " + marca.Nombre);
            
            //return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + marca.IDMarca, marca);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult DeleteMarca(int id) // Se eliminar por ID y no por Objeto de Marca.
        {
            var marca = _marca.GetMarca(id);

            if (marca != null)
            {
                _marca.DeleteMarca(id);
                return Ok("Se eliminó la marca");
            }

            return NotFound($"error al buscar la marca con el id: {id} ");


        }

        [HttpPatch]
        [Route("api/[controller]/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult EditMarca(MarcaDTO marca, int id)
        {
            var ExisteMarca = _marca.GetMarca(id);

            if (ExisteMarca != null)
            {
                marca.IDMarca = ExisteMarca.IDMarca;
                _marca.EditMarca(marca, id);                

            }

            return Ok("Se cambio la marca a: " + marca.Nombre);

        }




    }
}
