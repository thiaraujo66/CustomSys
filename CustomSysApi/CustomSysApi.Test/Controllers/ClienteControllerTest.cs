using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infra.Repository.Repositories.Cliente;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Domain.Entities;
using Domain.Contracts.UseCases.Cliente;
using Application.UseCases.Cliente;
using CustomSysApi.Controllers;
using CustomSysApi.Models.Response.Cliente;
using CustomSysApi.Models.Response.Padrao;
using Microsoft.AspNetCore.Mvc;
using CustomSysApi.Models.Error;
using CustomSysApi.Models.Cliente;
using CustomSysApi.Models.Request;

namespace CustomSysApi.Test.Controllers
{
    public class ClienteControllerTest
    {
        [Fact]
        public async Task GetClientes_DeveRetornarClientesComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                // Act
                var result = await controller.GetClientes();

                // Assert
                var okObjectResult = Assert.IsType<OkObjectResult>(result.Result);
                var baseReturn = Assert.IsType<BaseReturn<ClienteGetByIdResponse>>(okObjectResult.Value);
                var clientesResponse = Assert.IsType<List<ClienteGetByIdResponse>>(baseReturn.Data);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Consulta de Clientes realizada com sucesso", baseReturn.Status);
                Assert.NotEmpty(clientesResponse); // Verifica se a lista de clientes não está vazia
            }
        }

        [Fact]
        public async Task GetById_DeveRetornarClienteComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                var clienteIdExistente = "19054437065";

                var byIdRequest = new ByIdRequest<string> { Id = clienteIdExistente };

                // Act
                var result = await controller.GetById(byIdRequest);

                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var baseReturn = Assert.IsType<BaseReturn<ClienteGetByIdResponse>>(okObjectResult.Value);
                var clientesResponse = Assert.IsType<List<ClienteGetByIdResponse>>(baseReturn.Data);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Consulta de cliente realizada com sucesso", baseReturn.Status);
                Assert.NotEmpty(clientesResponse);
                Assert.Equal(clienteIdExistente, clientesResponse.FirstOrDefault().Id);
            }
        }

        [Fact]
        public async Task AddCliente_DeveIncluirClienteComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                var clienteInput = new ClienteInput
                {
                    Id = "78084843770",
                    Nome = "Renato Bruno Gomes",
                    Cgc = "780.848.437-70",
                    Sexo = "M",
                    CdEndereco = 1,
                    Email = "renato.bruno.gomes@dye.com.br",
                    Telefone = "8338332070",
                    Obs = "Teste Observação",
                    Excluido = false,
                    CdTipoCliente = 1,
                    CdSituacao = 1,
                    Nacionalidade = 1,
                    DtNasc = Convert.ToDateTime("23/08/2003"),
                    DtCad = DateTime.Now,
                    CdUsuCad = 1,
                    DtAlt = DateTime.Now,
                    CdUsualt = 1
                };

                // Act
                var result = await controller.AddCliente(clienteInput);

                // Assert
                var createdResult = Assert.IsType<CreatedResult>(result);
                var baseReturn = Assert.IsType<BaseReturn<Clientes>>(createdResult.Value);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Cliente inserido com sucesso", baseReturn.Status);
                Assert.Null(baseReturn.Data);
            }
        }

        [Fact]
        public async Task ExcluirCliente_DeveExcluirClienteComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                var clienteId = "78084843770";

                // Act
                var result = await controller.ExcluirCliente(clienteId);

                // Assert
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var baseReturn = Assert.IsType<BaseReturn<Clientes>>(okObjectResult.Value);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Cliente excluído com sucesso", baseReturn.Status);
            }
        }

        [Fact]
        public async Task AlterarCliente_DeveAlterarClienteComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                var clienteInput = new ClienteInput
                {
                    Id = "55142225007",
                    Nome = "Cliente 3",
                    Cgc = "551.422.250-07",
                    Sexo = "F",
                    CdEndereco = 3,
                    Email = "cliente3@email.com",
                    Telefone = "3334567890",
                    Obs = "Observação cliente 3 Alterado",
                    Excluido = false,
                    CdTipoCliente = 1,
                    CdSituacao = 1,
                    Nacionalidade = 3,
                    DtNasc = Convert.ToDateTime("1978-10-10"),
                    DtCad = Convert.ToDateTime("2023-11-24 17:40:00"),
                    CdUsuCad = 1,
                    DtAlt = DateTime.Now,
                    CdUsualt = 1
                };

                // Act
                var result = await controller.AlterarCliente(clienteInput);

                // Assert
                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var baseReturn = Assert.IsType<BaseReturn<Clientes>>(okObjectResult.Value);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Cliente alterado com sucesso", baseReturn.Status);
                Assert.Null(baseReturn.Data);
            }
        }

        [Fact]
        public async Task GetById_DeveRetornarClienteAlteradoComSucesso()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);
                var clienteValidator = new ClienteInputValidator();

                var controller = new ClienteController(clienteUseCase, clienteValidator);

                var clienteIdExistente = "55142225007";

                var byIdRequest = new ByIdRequest<string> { Id = clienteIdExistente };

                // Act
                var result = await controller.GetById(byIdRequest);

                var okObjectResult = Assert.IsType<OkObjectResult>(result);
                var baseReturn = Assert.IsType<BaseReturn<ClienteGetByIdResponse>>(okObjectResult.Value);
                var clientesResponse = Assert.IsType<List<ClienteGetByIdResponse>>(baseReturn.Data);

                Assert.True(baseReturn.IsSucces);
                Assert.Equal("Consulta de cliente realizada com sucesso", baseReturn.Status);
                Assert.NotEmpty(clientesResponse);
                Assert.Equal(clienteIdExistente, clientesResponse.FirstOrDefault().Id);
                Assert.Equal("F", clientesResponse.FirstOrDefault().Sexo);
                Assert.Equal("Observação cliente 3 Alterado", clientesResponse.FirstOrDefault().Obs);
            }
        }
    }
}
