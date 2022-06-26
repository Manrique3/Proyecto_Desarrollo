using Microsoft.Extensions.Logging;
using Moq;
using ProyectoDesarrolloSoftware.DataBase;
using ProyectoDesarrolloSoftware.DataBase.DAOs.Implementations;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ProyectoDesarrollo.Test.NewFolder
{
    public class MarcaDAOTs
    {
        private readonly MarcaDAO _DAO;
        private readonly Mock<DSDBContext> _contextMock = new Mock<DSDBContext>();
        private readonly Mock<ILogger<MarcaDAO>> _mockLogger = new Mock<ILogger<MarcaDAO>>();

        public MarcaDAOTs()
        {
            _DAO = new MarcaDAO(_contextMock.Object);
            
        }

        [Fact]
        public Task ShouldShowBrands_GetMarcas()
        {
            var result = _DAO.GetMarcas();
            var data = result;
            Assert.True(data.Any());//ERROR
            return Task.CompletedTask;
            
        }
    }
}
