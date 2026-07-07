
using ControleEstoque.API.Controllers;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ControleEstoque.API.Tests.Controllers
{
    public class ProdutosControllerTests
    {
        [Fact]
        public async Task GetById_ProdutoNaoEncontrado_DeveRetornarNotFound()
        {
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.ObterPorIdAsync(23))  // It.IsAny<int>() é usado para indicar que qualquer valor inteiro pode ser passado como argumento para o método ObterPorIdAsync                                                                                   // serve para simular o comportamento do método ObterPorIdAsync do serviço de produtos
                      .ReturnsAsync((ProdutoDto?)null);
            var controller = new ProdutosController(mockService.Object); // object é usado para passar a instância mockada do serviço para o controlador

            // Act
            var result = await controller.GetById(23);


            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ProdutoCriado_DeveRetornarCreatedAtAction()
        {
            //Arrange
            var mockService = new Mock<IProdutoService>();
            var novoProdutoDto = new CriarProdutoDto
            {
     
                Nome = "Teclado",
                Preco = 10.0m,
                FornecedorId = 1,
                QuantidadeEstoque = 10
            };

            var produtoRetonadoDaService = new ProdutoDto
            {
                Id = 23,
                Nome = "Teclado",
                Preco = 559.99m,
                FornecedorId = 1,
                QuantidadeEstoque = 10
            };

            mockService.Setup(service => service.CriarAsync(It.IsAny<CriarProdutoDto>()))
                       .ReturnsAsync(produtoRetonadoDaService);
            var controller = new ProdutosController(mockService.Object);

            // Act
            var result = await controller.Create(new CriarProdutoDto { Nome = "Teclado", Preco = 10.0m, FornecedorId = 1, QuantidadeEstoque = 10});

            // Assert
            var createdResult = Assert.IsType<CreatedAtActionResult>(result);

            Assert.Equal(23, ((ProdutoDto)createdResult.Value!).Id);
            Assert.Equal("Teclado", ((ProdutoDto)createdResult.Value!).Nome);
        }

        [Fact]
        public async Task Update_IdDiferente_DeveRetornarBadRequest()
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            var controller = new ProdutosController(mockService.Object);
            var atualizarProdutoDto = new AtualizarProdutoDto
            {
                Id = 1,
                Nome = "Teclado Mecânico RGB",
                Preco = 20.0m,
                FornecedorId = 1,
                QuantidadeEstoque = 5
            };
            // Act
            var result = await controller.Update(2, atualizarProdutoDto); // Passando um ID diferente do DTO
            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Contains("Ação incorreta", badRequestResult.Value?.ToString()); // Contains serve para verificar se a mensagem de erro contém a frase esperada
            // Assert.Equal("O ID da rota difere do ID do produto.", badRequestResult.Value);
        }

        [Fact] 
        public async Task Delete_QuandoServicoCompleta_DeveRetornarNoContent()
        {
            // Arrange
            var mockService = new Mock<IProdutoService>();
            mockService.Setup(service => service.RemoverAsync(1)).Returns(Task.CompletedTask);
            var controller = new ProdutosController(mockService.Object);
            // Act
            var result = await controller.Delete(1);
            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
