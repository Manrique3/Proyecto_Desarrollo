/*using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrolloSoftware.DTO;
using ProyectoDesarrolloSoftware.Controllers;
using ProyectoDesarrolloSoftware.Exceptions;
using ProyectoDesarrolloSoftware.AccesoDatos.DAOs;
using ProyectoDesarrolloSoftware.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace ProyectoDesarrollo.Test.UnitTests.Controllers
{
    public class PiezasControllerTest
    {
        private readonly PiezasController _controller;
        private readonly Mock<IPiezasDAO> _serviceMock;
        private readonly Mock<ILogger<PiezasController>> _loggerMock;

        public PiezasControllerTest()
        {
            _loggerMock = new Mock<ILogger<PiezasController>>();
            _serviceMock = new Mock<IPiezasDAO>();
            _controller = new PiezasController(_loggerMock.Object, _serviceMock.Object);
            _controller.ControllerContext = new ControllerContext();
            _controller.ControllerContext.HttpContext = new DefaultHttpContext();
            _controller.ControllerContext.ActionDescriptor = new ControllerActionDescriptor();            
        }

        [Fact(DisplayName = "Get lista de piezas by Name")]
        public Task GetPiezaByName()
        {
            _serviceMock
               .Setup(x => x.GetListaPiezasByName(It.IsAny<string>()))
               .Returns(new List<PiezaDTO>());
            var result = _controller.GetPiezasByName("");

            Assert.IsType<ProyectoDesarrolloSoftware.Responses.ApplicationResponse<List<PiezaDTO>>>(result);    
            
            return Task.CompletedTask;
        }

        [Fact(DisplayName = "Get pieza by Id")]
        public Task GetPiezaById()
        {
            _serviceMock
               .Setup(x => x.GetPieza(It.IsAny<int>()))
               .Returns(new PiezaDTO());
            var result = _controller.GetPieza(102);
            var obj = JArray.FromObject(result);
            
            Assert.Equal(1, obj.Count);

            return Task.CompletedTask;
        }

        /*[Fact(DisplayName = "Agregar una Pieza")]

        public Task AgregarPieza()
        {
            var  pieza = new PiezaDTO();
            pieza.Id_Pieza = 100;
            pieza.Nombre = "Pieza de carrito";
            _serviceMock
                .Setup(x => x.Add(pieza))
                .Verifiable();
            var result = _controller.GetPieza(100);

            Assert.Equal((IEnumerable<PiezaDTO>)result, (IEnumerable<PiezaDTO>)pieza);

            return Task.CompletedTask;

        }*/


 //   }
//}
