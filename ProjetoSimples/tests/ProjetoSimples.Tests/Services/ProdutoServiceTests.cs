using ProjetoSimples.API.Models;
using ProjetoSimples.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoSimples.Tests.Services
{
    public class ProdutoServiceTests
    {
        [Fact]
        public void Adicionar_DeveInserirProdutoERetornarProdutoComIdGerado()
        {
            // Arrange
            var service = new ProdutoService();
            var produto = new Produto { Nome = "Mouse USB", Preco = 150.0m };

            // Act
            var resultado = service.Adicionar(produto);

            // Assert
            Assert.True(resultado.Id > 0);
            Assert.Equal("Mouse USB", resultado.Nome);
            Assert.Single(service.ObterTodos());
        }

        [Fact]
        public void ObterPorId_DeveRetonarNulo_QuandoProdutoNaoExiste()
        {
            // Arrange
            var service = new ProdutoService();

            // Act
            var resultado = service.ObterPorId(999);

            // Assert
            Assert.Null(resultado);
        }
    }
}
