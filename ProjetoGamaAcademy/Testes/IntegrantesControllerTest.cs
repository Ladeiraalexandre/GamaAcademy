using ProjetoGamaAcademy.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading.Tasks;
using Xunit;
using System;
using System.Threading;
using System.Collections.Generic;
using API.Controllers;

namespace Testes
{
    public class IntegrantesControllerTest
    {
        private readonly Mock<DbSet<Integrantes>> _mockSet;
        private readonly Mock<Context> _mockContext;
        private readonly Integrantes _integrantes;


        public IntegrantesControllerTest() 
        {

            _mockSet = new Mock<DbSet<Integrantes>>();
            _mockContext = new Mock<Context>();
            _integrantes = new Integrantes { Id = 1, Nome = "Teste Nome" };

            _mockContext.Setup(m => m.Integrantes).Returns(_mockSet.Object);


            _mockContext.Setup(m => m.Integrantes.FindAsync(1))
                .ReturnsAsync(_integrantes);

            _mockContext.Setup(m => m.SetModified(_integrantes));

            _mockContext.Setup(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()))
                .ReturnsAsync(1);
        }

        [Fact]
        public async Task Get_Integrantes()
        {
            var service = new IntegrantesController(_mockContext.Object); 

            await service.GetIntegrantes(1); 

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
        }

        [Fact]
        public async Task Put_Integrantes()
        {
            var service = new IntegrantesController(_mockContext.Object);

            await service.PutIntegrantes(1, _integrantes);

            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Post_Integrantes()
        {
            var service = new IntegrantesController(_mockContext.Object);
            await service.PostIntegrantes(_integrantes);

            _mockSet.Verify(x => x.Add(_integrantes), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

        [Fact]
        public async Task Delete_Categoria()
        {
            var service = new IntegrantesController(_mockContext.Object);
            await service.DeleteIntegrantes(1);

            _mockSet.Verify(m => m.FindAsync(1),
                Times.Once());
            _mockSet.Verify(x => x.Remove(_integrantes), Times.Once);
            _mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()),
                Times.Once());
        }

    }
}
