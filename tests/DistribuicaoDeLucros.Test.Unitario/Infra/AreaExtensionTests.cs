using System.Linq;
using System.Threading.Tasks;
using DistribuicaoDeLucros.Infra.Context;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario.Infra;

public class AreaExtensionTests : BaseTests
{

    [Fact]
    public void DeveCarregarSeisAreasDeAtuacao()
    {
        //Act
        Context.Initialize();
        var areas = Context.Area.ToList();
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