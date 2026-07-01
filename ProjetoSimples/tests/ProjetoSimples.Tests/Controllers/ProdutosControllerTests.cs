using Microsoft.AspNetCore.Mvc;
using Moq;
using ProjetoSimples.API.Controllers;
using ProjetoSimples.API.Models;
using ProjetoSimples.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSimples.Tests.Controllers
{
    public class ProdutosControllerTests  
    {
        [Fact]
        public void GetById_DeveRetornarOk_QuandoProdutoExistir()
        {
            //Arrange
            var mockService = new Mock<IProdutoService>(); // Mock serve para criar uma implementação falsa da interface IProdutoService
      
            mockService.Setup(service => service.ObterPorId(40))
                .Returns(new Produto { Nome = "Mouse USB", Preco = 150.0m }); // Setup define o comportamento do método ObterPorId quando chamado com o parâmetro 1

            var controller = new ProdutosController(mockService.Object);

            //Act
            var result = controller.GetById(40);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result); // Verifica se o resultado é do tipo OkObjectResult
            var produtoRetornado = Assert.IsType<Produto>(okResult.Value); // Verifica se o valor retornado é do tipo Produto, o Value é a propriedade que contém o objeto retornado pelo OkObjectResult
            Assert.Equal("Mouse USB", produtoRetornado.Nome);

        }

    }
}
