using ControleEstoque.API.Controllers;
using ControleEstoque.API.DTOs;
using ControleEstoque.API.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace ControleEstoque.API.Tests.Controllers
{
    public class UsuariosControllerTests
    {
        [Fact]
        public async Task Autenticar_QuandoCredencialInvalida_RetornarUnathorized()
        {
            // Arrange
            var login = new LoginDto
            {
                Email = "diego@mail.com",
                Senha = "senhaInvalida"
            };

            var loginCorreto = new LoginDto
            {
                Email = "diego@mail.com",
                Senha = "senhaValida"
            };

            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.AutenticarAsync(loginCorreto))
                       .ReturnsAsync((TokenDto?)null);

            var controller = new UsuariosController(mockService.Object);
            // Act
            var result = await controller.Autenticar(login);
           
            // Assert
            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Contains("Credenciais inválidas", unauthorized.Value?.ToString());

        }

        [Fact]
        public async Task RegistrarCliente_QuandoSucesso_DeveRetornarCreatedAtAction()
        {
            // Arrange
            var dto = new CriarClienteDto
            {
                Nome = "Diego",
                CPF = "12345678900",
                Email = "diego@mail.com",
                Senha = "senhaSegura"
            };

            var mockService = new Mock<IUsuarioService>();
            mockService.Setup(service => service.RegistrarClienteAsync(dto))
                       .ReturnsAsync(new UsuarioDto
                       {
                           Id = 1,
                           Nome = dto.Nome,
                           CPF = dto.CPF,
                           Email = dto.Email
                       });

            var controller = new UsuariosController(mockService.Object);

            // Act
            var result = await controller.RegistrarCliente(dto);

            // Assert
            var createdAtAction = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(1, ((UsuarioDto)createdAtAction.Value!).Id);
            Assert.Equal(dto.Nome, ((UsuarioDto)createdAtAction.Value!).Nome); // Serve para verificar se o nome retornado é o mesmo que foi enviado no DTO
        }   
  

            }
    }
