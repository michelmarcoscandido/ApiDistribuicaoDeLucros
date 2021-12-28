using System.Collections.Generic;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Bogus;
using DistribuicaoDeLucros.Infra.Context;
using System.Linq;
using FluentAssertions;

namespace DistribuicaoDeLucros.Test.Unitario.Services
{
    public class FuncionarioServiceTests : BaseTests
    {

        [Fact]
        public void ArmazenaUmaListaDeFuncionariosNaBaseDeDadosDeveGravarTodosOsRegistrosCorretamente() {
            
            //Arange
            using var context = ServiceProvider.GetService<SqlContext>();
            var area = context.Area.FirstOrDefault();
            
            var faker = new Faker("en");

            var funcionarioService = ServiceProvider.GetService<IFuncionarioService>();
            List<Funcionario> funcionarios = new (){};

            for(int i = 0; i<2; i ++) {
                funcionarios.Add(new Funcionario(){
                    Nome = faker.Person.FullName,
                    Matricula = faker.Random.AlphaNumeric(10),
                    Cargo = faker.Name.JobArea(),
                    SalarioBruto = faker.Random.Decimal(1000.62m, 5982.23m),
                    DataDeAdimissao = faker.Date.PastDateOnly(),
                    Area = area
                });
            }

            //Act
            funcionarioService.ArmazenarFuncionariosAsync(funcionarios);
            var funcionariosBase = context.Funcionario.ToList();

            //Assert
            funcionariosBase.Should().HaveCount(funcionarios.Count());        
        }

    }
}
