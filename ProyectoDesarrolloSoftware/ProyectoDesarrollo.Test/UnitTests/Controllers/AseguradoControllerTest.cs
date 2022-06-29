/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.Controllers;
using Xunit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Responses;
using ProyectoDesarrolloSoftware.Exceptions;

namespace ProyectoDesarrollo.Test.UnitTests.Controllers
{
    public class AseguradoControllerTest
    {
        private readonly AseguradosController _controller;
        private readonly Mock<IAseguradoDAO> _serviceMock;
        private readonly Mock<ILogger<AseguradosController>> _loggerMock;

        public AseguradoControllerTest()
        {
            _loggerMock = new Mock<ILogger<AseguradosController>>();
            _serviceMock = new Mock<IAseguradoDAO>();
            _controller = new AseguradosController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();
        }

        [Fact(DisplayName = "Get Asegurados")]
        public Task VerRegistrosAsegurado()
        {
            _serviceMock
                .Setup(x => x.VerRegistrosAsegurado(It.IsAny<string>()))
                .Returns(new List<AseguradoDTO>());

            var result = _controller.VerRegistrosAsegurado("");

            Assert.IsType<ApplicationResponse<List<AseguradoDTO>>>(result);
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get Asegurados with Exception")]
        public Task GetProvidersByBrandException()
        {
            _serviceMock
                .Setup(x => x.VerRegistrosAsegurado(It.IsAny<string>()))
                .Throws(new Excepciones("", new Exception()));

            var ex = _controller.VerRegistrosAsegurado("");

            Assert.NotNull(ex);
            Assert.False(ex.Success);
            return Task.CompletedTask;
        }


    }
}*/
