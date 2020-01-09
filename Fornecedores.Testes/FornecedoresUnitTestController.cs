using Fornecedores.Api.Extensions;
using Fornecedores.Data.Context;
using Fornecedores.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;
namespace Fornecedores.Testes
{

    public class FornecedoresUnitTestController
    {
        private FornecedorRepository repository;
        public static DbContextOptions<MeuDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost;Database=UsuariosJuntoJwt;Integrated Security=true;MultipleActiveResultSets=true";

        static FornecedoresUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<MeuDbContext>()
                .UseSqlServer(connectionString)
                .Options;
        }

        public FornecedoresUnitTestController()
        {
            var context = new MeuDbContext(dbContextOptions);
            CadastraFornecedor(context);
            repository = new FornecedorRepository(context);
        }

        internal void CadastraFornecedor(MeuDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            context.Fornecedores.AddRange(
                new Business.Models.Fornecedor() { Nome = "CSHARP", Ativo = true }
            );
            context.SaveChanges();
        }

        [Fact]
        public async void TaskObterTodosRetornaOkResult()
        {
            //Arrange  
            var controller = new Api.V1.Controllers.FornecedoresController(repository, new Business.Notificacoes.Notificador(), new AspNetUser());
            //Act  
            var data = await controller.ObterTodos();
            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }
    }
}
