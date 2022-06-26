using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrolloSoftware.Controllers;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations;
using ProyectoDesarrolloSoftware.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using static ProyectoDesarrolloSoftware.Responses.ResponsesProyecto;

namespace ProyectoDesarrollo.Test.NewFolder
{
    public class ControladorMarcaTest
    {
        private readonly ControladorMarca _controlador;
        private readonly Mock<IMarcaDAO> _servicesMock;
        private readonly Mock<ILogger<ControladorMarca>> _loggerMock;

        public ControladorMarcaTest()
        {
            _controlador =  new ControladorMarca(_loggerMock.Object, _servicesMock.Object);
            _loggerMock = new Mock<ILogger<ControladorMarca>>();
            _servicesMock = new Mock<IMarcaDAO>();
            _controlador.ControllerContext = new ControllerContext();
            _controlador.ControllerContext.HttpContext = new DefaultHttpContext();
            _controlador.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
            
        }

        [Fact]
        public Task ShouldShowBrands_GetMarcas()
        {
            _servicesMock
                 .Setup(x => x.GetMarcas())
                 .Returns(new List<MarcaDTO>());

            var ex = _controlador.GetMarcas();
            Assert.IsType<ApplicationResponse<List<MarcaDTO>>>(ex);
            return Task.CompletedTask;
        }
    }
}
