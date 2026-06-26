using UtilitariosApp;
using Xunit;


namespace UtilitariosApp.Tests
{

    public class ClienteTests
    {

        [Fact]
        public void Cliente_DeveTerPropriedadesCorretas()
        {
            //Arrange
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "souza.santos@mial.com";

            //Act
            var cliente = new Cliente(id, nome, email, endereco);

            //Assert
            Assert.NotNull(cliente);
            Assert.Equal(id, cliente.Id);
            Assert.Equal(nome, cliente.Nome);
            Assert.Equal(email, cliente.Email);
            Assert.NotNull(endereco);
        }

        [Fact]
        public void Cliente_DeveContribuirEnderecoCorreto()
        {
            //Arrange
            var endereco = new Endereco("Rua Tito", 54, "São Paulo", "SP");
            int id = 87;
            string nome = "Souza Santos";
            string email = "souza.santos@mial.com";

            //Act
            var cliente = new Cliente(id, nome, email, endereco);
            var enderecoFormatado = cliente.Endereco.FormatarEndereco();

            //Assert
            Assert.Equal("Rua Tito, 54, São Paulo, SP", enderecoFormatado);

        }

        [Fact]
        public void EmailValido_ComEmailCorreto_DeveRetornarVerdadeiro()
        {
            // Arrange
            var cliente = new Cliente(
                1,
                "Diego",
                "diego@email.com",
                null!
            );

            // Act
            bool resultado = cliente.EmailValido();

            // Assert
            Assert.True(resultado);
        }

        [Fact]
        public void EmailValido_SemArroba_DeveRetornarFalso()
        {
            // Arrange
            var cliente = new Cliente(
                1,
                "Diego",
                "diegoemail.com",
                null!
            );

            // Act
            bool resultado = cliente.EmailValido();

            // Assert
            Assert.False(resultado);
        }

        [Fact]
        public void EmailValido_SemPonto_DeveRetornarFalso()
        {
            // Arrange
            var cliente = new Cliente(
                1,
                "Diego",
                "diego@email",
                null!
            );

            // Act
            bool resultado = cliente.EmailValido();

            // Assert
            Assert.False(resultado);
        }
    }
}





        //public void EmailValido_DeveRetornarTrue_QuandoEmailTemArrobaEPonto()
        //{
        //    // Arrange
        //    var cliente = new Cliente(
        //        1,
        //        "Diego",
        //        "diego@email.com",
        //        null!
        //    );

//    // Act
//    bool resultado = cliente.EmailValido();

//    // Assert
//    Assert.True(resultado);
//}

//[Fact]
//public void EmailValido_DeveRetornarFalse_QuandoEmailNaoTemArroba()
//{
//    // Arrange
//    var cliente = new Cliente(
//        1,
//        "Diego",
//        "diegoemail.com",
//        null!
//    );

//    // Act
//    bool resultado = cliente.EmailValido();

//    // Assert
//    Assert.False(resultado);
//}

//[Fact]
//public void EmailValido_DeveRetornarFalse_QuandoEmailNaoTemPonto()
//{
//    // Arrange
//    var cliente = new Cliente(
//        1,
//        "Diego",
//        "diego@email",
//        null!
//    );

//    // Act
//    bool resultado = cliente.EmailValido();

//    // Assert
//    Assert.False(resultado);
//}

