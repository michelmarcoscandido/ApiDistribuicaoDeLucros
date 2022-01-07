using System;
using Bogus;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Services.Handlers;
using FluentAssertions;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario.Handlers
{
    public class HandlerTests
    {
        [Fact]
        public void DeveEstartudoOKQuandoOsDadosSaoEnviados() {
          var participacao = new Participacao(){
            Funcionario = new Funcionario () {
              Area = new Area(){}
            }
          };
          var areaDeAtuacao = new AreaDeAtuacaoHandler();

          
          areaDeAtuacao
          .SetNext(new FaixaSalarialHandler())
          .SetNext(new TempoDeAdmissaoHandler())
          .SetNext(new CalcularParticipacaoHandler());
          
          areaDeAtuacao.Handle(participacao)
          .Should().BeOfType<Participacao>();

        }

        [Theory]
        [InlineData(0, 1, 6305.04)]
        [InlineData(-2, 2, 8406.72)]
        [InlineData(-4, 3, 10508.40)]
        [InlineData(-6, 3, 10508.40)]
        [InlineData(-8, 5, 14711.76)]
        public void DeveCalcularAParticipacaoQuandoOFuncionarioEviadoEstaComTodosOsDadosPreenchidosVariandoOAno(int anosAseremAdicionadosOuSubtraidosDoAnoCorrente, int resultadoTempoAdimissao, decimal resultadoCalculo) {
            var faker = new Faker("en");
            
            var funcionario = new Funcionario () {
                Nome = faker.Person.FullName,
                Matricula = faker.Random.AlphaNumeric(10),
                Cargo = faker.Name.JobArea(),
                SalarioBruto = 2101.68m,
                DataDeAdimissao = DateOnly.FromDateTime(DateTime.Today.AddYears(anosAseremAdicionadosOuSubtraidosDoAnoCorrente)),
                Area = new Area() { Descricao = "Descricao", Peso = 2}    
            };
          var participacao = new Participacao()
          {
            Funcionario = funcionario
          }
          ;
          var areaDeAtuacao = new AreaDeAtuacaoHandler();
            areaDeAtuacao
              .SetNext(new FaixaSalarialHandler())
              .SetNext(new TempoDeAdmissaoHandler())
              .SetNext(new CalcularParticipacaoHandler());
          var retornoParticipacao = areaDeAtuacao.Handle(participacao);
          retornoParticipacao.PesoPorAreaDeAtuacao.Should().Be(2);
          retornoParticipacao.PesoPorFaixaSalarial.Should().Be(3);
          retornoParticipacao.PesoPortempoDeAdmissao.Should().Be(resultadoTempoAdimissao);
          retornoParticipacao.ValorParticipacao.Should().Be(resultadoCalculo);
        }
        

        [Theory]
        [InlineData(790, 1, 7110)]
        [InlineData(2000, 1, 18000)]
        [InlineData(4000.87, 3, 12002.61)]
        [InlineData(7000.01, 5, 12600.02)]
        [InlineData(7777.77, 5, 13999.99)]
        public void DeveCalcularAParticipacaoQuandoOFuncionarioEviadoEstaComTodosOsDadosPreenchidosVariandoFaixaSalarial(decimal faixaSalarial, int resultadoFaixaSalarial, decimal resultadoCalculo) {
            var faker = new Faker("en");
            
            var funcionario = new Funcionario () {
                Nome = faker.Person.FullName,
                Matricula = faker.Random.AlphaNumeric(10),
                Cargo = faker.Name.JobArea(),
                SalarioBruto = faixaSalarial,
                DataDeAdimissao = DateOnly.FromDateTime(DateTime.Now),
                Area = new Area() { Descricao = "Descricao", Peso = 2}    
            };
          var participacao = new Participacao()
          {
            Funcionario = funcionario
          }
          ;
          var areaDeAtuacao = new AreaDeAtuacaoHandler();

          
            areaDeAtuacao
              .SetNext(new FaixaSalarialHandler())
              .SetNext(new TempoDeAdmissaoHandler())
              .SetNext(new CalcularParticipacaoHandler());
          var retornoParticipacao = areaDeAtuacao.Handle(participacao);
          retornoParticipacao.PesoPorAreaDeAtuacao.Should().Be(2);
          retornoParticipacao.PesoPorFaixaSalarial.Should().Be(resultadoFaixaSalarial);
          retornoParticipacao.PesoPortempoDeAdmissao.Should().Be(1);
          retornoParticipacao.ValorParticipacao.Should().Be(resultadoCalculo);
        }

        [Theory]
        [InlineData(1, 12000)]
        [InlineData(2, 18000)]
        [InlineData(3, 24000)]
        [InlineData(5, 36000)]
        
        public void DeveCalcularAParticipacaoQuandoOFuncionarioEviadoEstaComTodosOsDadosPreenchidosVariandoPesoAreaDeAtuacao(int pesoAreaDeAtuacao, decimal resultadoCalculo) {
            var faker = new Faker("en");
            
            var funcionario = new Funcionario () {
                Nome = faker.Person.FullName,
                Matricula = faker.Random.AlphaNumeric(10),
                Cargo = faker.Name.JobArea(),
                SalarioBruto = 2000,
                DataDeAdimissao = DateOnly.FromDateTime(DateTime.Now),
                Area = new Area() { Descricao = "Descricao", Peso = pesoAreaDeAtuacao}    
            };
          var participacao = new Participacao()
          {
            Funcionario = funcionario
          }
          ;
          var areaDeAtuacao = new AreaDeAtuacaoHandler();
            areaDeAtuacao
              .SetNext(new FaixaSalarialHandler())
              .SetNext(new TempoDeAdmissaoHandler())
              .SetNext(new CalcularParticipacaoHandler());
          var retornoParticipacao = areaDeAtuacao.Handle(participacao);
          retornoParticipacao.PesoPorAreaDeAtuacao.Should().Be(pesoAreaDeAtuacao);
          retornoParticipacao.PesoPorFaixaSalarial.Should().Be(1);
          retornoParticipacao.PesoPortempoDeAdmissao.Should().Be(1);
          retornoParticipacao.ValorParticipacao.Should().Be(resultadoCalculo);
        }
    }
}
