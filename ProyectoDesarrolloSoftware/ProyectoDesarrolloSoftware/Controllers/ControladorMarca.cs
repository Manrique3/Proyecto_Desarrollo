using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProyectoDesarrolloSoftware.Controllers
{
    
    [ApiController]
    public class ControladorMarca : ControllerBase
    {
        private IMarcaDAO _marca;
        public ControladorMarca(IMarcaDAO marca)
        {
            _marca = marca;

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
        [Route("api/[controller]")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult GetMarca(MarcaDTO marca)
        {
             _marca.AddMarca(marca);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + marca.IDMarca, marca);

        }
        [HttpDelete]
        [Route("api/[controller]/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult DeleteMarca(int id)
        {
            var marca = _marca.GetMarca(id);

            if (marca != null)
            {
                _marca.DeleteMarca(marca);
                return Ok("Se eliminó la marca");
            }

            return NotFound($"error al buscar la marca con el id: {id} ");


        }

        [HttpPatch]
        [Route("api/[controller]/{id}")] // Ruta en la que se muestra una marca dependiendo de id
        public IActionResult EditMarca(int id, MarcaDTO marca)
        {
            var ExisteMarca = _marca.GetMarca(id);

            if (ExisteMarca != null)
            {
                marca.IDMarca = ExisteMarca.IDMarca;
                _marca.EditMarca(marca);
               
            }

            return Ok("Se cambio la marca a: " + marca);

        }




    }
}
