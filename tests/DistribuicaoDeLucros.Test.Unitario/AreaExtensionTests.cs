using System.Linq;
using System.Threading.Tasks;
using DistribuicaoDeLucros.Infra.Context;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario;

public class AreaExtensionTests
{

    public AreaExtensionTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection
                        .AddDbContext<SqlContext>(
                            options => options.UseInMemoryDatabase(databaseName: "DistribuicaoDeLucros"),
                            ServiceLifetime.Transient
                        );
         ServiceProvider = serviceCollection.BuildServiceProvider();
    }
    private readonly ServiceProvider ServiceProvider;

    [Fact]
    public void CarregarOsDadosAoIniciarAAplicacaoDeveRetornarAsAreas()
    {
        //Arange
        ServiceProvider.Initialize();
        using var context = ServiceProvider.GetService<SqlContext>();

        //Act
        var areas = context.Area.ToList();
        
        //Assert
        areas.Should().HaveCount(6);
        areas.Where(x => x.Descricao.Equals("Diretoria")).Should().NotBeNull();
        areas.Where(x => x.Descricao.Equals("Contabilidade")).Should().NotBeNull();
        areas.Where(x => x.Descricao.Equals("Financeiro")).Should().NotBeNull();
        areas.Where(x => x.Descricao.Equals("Tecnologia")).Should().NotBeNull();
        areas.Where(x => x.Descricao.Equals("Serviços Gerais")).Should().NotBeNull();
        areas.Where(x => x.Descricao.Equals("Relacionamento com o Cliente")).Should().NotBeNull();

    }
}