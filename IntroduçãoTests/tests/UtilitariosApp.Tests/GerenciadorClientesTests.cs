

namespace UtilitariosApp.Tests
{
    public class GerenciadorClientesTests
    {
        [Fact]
        public void AdicionarClientes_AoAdicionarCliente_DeveAumentaraQuantidade()
        {
            ////Arrange
            var gerenciadorClientes = new GerenciadorClientes();
            var endereco = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente = new Cliente(2, "Marcio", "marcio@mail.com", endereco);



            //Act
            gerenciadorClientes.AdicionarCliente(cliente);



            //Assert
            Assert.Equal(1, gerenciadorClientes.ContarClientes());


        }

        [Fact]
        public void AdicionarCliente_ComClienteNulo_DeveLancarArgumentNullException()
        {

            //Arrange
            var gerenciador = new GerenciadorClientes();

            //Act e Assert
            Assert.Throws<ArgumentNullException>(() => gerenciador.AdicionarCliente(null));

        }


        [Fact]
        public void AdicionarCliente_VariosClientesValidos_DeveAdicionarTodos()
        {
            // Arrange
            var gerenciador = new GerenciadorClientes();

            var cliente1 = new Cliente(
                1,
                "silva",
                "silva@mail.com",
                new Endereco("Rua A", 10, "São Paulo", "SP")
            );

            var cliente2 = new Cliente(
                2,
                "Marcio",
                "marcio@mail.com",
                new Endereco("Rua B", 20, "São Paulo", "SP")
            );

            var cliente3 = new Cliente(
                3,
                "Luana",
                "Luana@mail.com",
                new Endereco("Rua C", 30, "São Paulo", "SP")
            );

            // Act
            gerenciador.AdicionarCliente(cliente1);
            gerenciador.AdicionarCliente(cliente2);
            gerenciador.AdicionarCliente(cliente3);

            // Assert
            Assert.Equal(3, gerenciador.ContarClientes());
        }

        [Fact]
        public void BuscarClientePorId_QuandoIdExistir_DeveRetornarCliente()
        {
            // Arrange
            var gerenciador = new GerenciadorClientes();

            var endereco = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente = new Cliente(2, "Marcio", "marcio@mail.com", endereco);

            gerenciador.AdicionarCliente(cliente);

            // Act
            var clienteEncontrado = gerenciador.ProcurarPorId(2);

            // Assert
            Assert.NotNull(clienteEncontrado);
            Assert.Equal(2, clienteEncontrado.Id);
            Assert.Equal("Marcio", clienteEncontrado.Nome);
        }


        [Fact]    
        public void BuscarClientePorId_QuandoIdNaoExistir_DeveRetornarNulo()
        {
            // Arrange
            var gerenciador = new GerenciadorClientes();

            var endereco = new Endereco("Rua B", 123, "São Paulo", "SP");
            var cliente = new Cliente(2, "Marcio", "marcio@mail.com", endereco);

            gerenciador.AdicionarCliente(cliente);

            // Act
            var clienteEncontrado = gerenciador.ProcurarPorId(99);

            // Assert
            Assert.Null(clienteEncontrado);
        }

    }
}

