using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoDesarrolloSoftware.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoDesarrolloSoftware.Controllers
{
    
    [ApiController]
    public class ControladorMarca : ControllerBase
    {
        private IMarca _marca;
        public ControladorMarca(IMarca marca)
        {
            _marca = marca;

        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetMarcas()
        {
            return Ok(_marca.GetMarcas());
        }


    }
}
