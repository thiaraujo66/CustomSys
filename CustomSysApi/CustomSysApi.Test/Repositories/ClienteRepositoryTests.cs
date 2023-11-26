using Infra.Repository.Repositories.Cliente;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Domain.Entities;
using Application.UseCases.Cliente;


namespace CustomSysApi.Test.Repositories
{
    public class ClienteRepositoryTests
    {
        [Fact]
        public async Task GetById_DeveRetornarCliente()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);

                var customerId = "19054437065";

                // Act
                var result = await clienteUseCase.GetById(customerId);

                // Assert
                Assert.NotNull(result);
                Assert.Equal(customerId, result.Clid);
            }
        }

        [Fact]
        public async Task AddCliente_DeveAdicionarNovoCliente()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {
                Clientes cliente = new Clientes
                {
                    Clid = "78084843770",
                    Clnome = "Renato Bruno Gomes",
                    Clcgc = "780.848.437-70",
                    Clsexo = "M",
                    Clcdendereco = 1,
                    Clemail = "renato.bruno.gomes@dye.com.br",
                    Cltelefone = "8338332070",
                    Clobs = "Teste Observação",
                    Clexcluido = false,
                    Clcdtipocliente = 1,
                    Clcdsituacao = 1,
                    Clnacionalidade = 1,
                    Cldtnasc = Convert.ToDateTime("23/08/2003"),
                    Cldtcad = DateTime.Now,
                    Clcdusucad = 1,
                    Cldtalt = DateTime.Now,
                    Clcdusualt = 1
                };

                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);

                clienteUseCase.AddCliente(cliente);

                // Act
                var result = await clienteUseCase.SaveAllAsync();

                // Assert
                Assert.True(result);

                clienteUseCase.Excluir(cliente);

                var result2 = await clienteUseCase.SaveAllAsync();

                Assert.True(result2);
            }
        }

        [Fact]
        public async Task AlterarCliente_DeveAtualizarSexo()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {

                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);

                var customerId = "19054437065";

                Clientes cliente = await clienteUseCase.GetById(customerId);

                cliente.Clsexo = "F";

                clienteUseCase.Alterar(cliente);

                // Act
                var result = await clienteUseCase.SaveAllAsync();

                // Assert
                Assert.True(result);

                Clientes clienteAlterado = await clienteUseCase.GetById(customerId);


                Assert.NotNull(clienteAlterado);
                Assert.Equal("F", clienteAlterado.Clsexo);
            }
        }

        [Fact]
        public async Task SelecionarTodos_DeveRetornarTodosClientes()
        {
            string connectionString = "Server=;Database=CUSTOMSYS;User Id=sa;Password=;Encrypt=False";
            var options = new DbContextOptionsBuilder<CUSTOMSYSContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var context = new CUSTOMSYSContext(options))
            {

                var repository = new ClienteRepository(context);
                var clienteUseCase = new ClienteUseCase(repository);

                IEnumerable<Clientes> cliente = await clienteUseCase.SelecionarTodos();

                Assert.NotNull(cliente);
                Assert.True(cliente.Count() >= 1, "A Quantidade de retorno deve ser maior ou igual à 1");
            }
        }
    }
}
