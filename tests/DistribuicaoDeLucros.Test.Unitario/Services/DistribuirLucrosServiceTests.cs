using System.Collections.Generic;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Bogus;
using System.Linq;
using FluentAssertions;
using System.Threading.Tasks;
using System;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Test.Unitario.Services
{
    public class DistribuirLucrosServiceTests : BaseTests
    {
        [Fact]
        public async Task DeveArmazenarUmaListaDeFuncionario() {
            
            //Arange
            var area = new Area(){
                Descricao = "Diretoria", 
                Peso = 1
            };
            var areaRepository = ServiceProvider.GetService<IAreaRepository>();
            var uow = ServiceProvider.GetService<IUnitOfWork>();
            await areaRepository.InsertAsync(area);
            await uow.SaveChangesAsync();

            var distribuirLucrosService = ServiceProvider.GetService<IDistribuirLucrosService>();
            List<Funcionario> funcionarios = new (){
                new Funcionario(){
                    Nome = "nome",
                    Matricula = "123123",
                    Cargo = "cargo",
                    SalarioBruto = 1762.87m,
                    DataDeAdimissao = DateOnly.FromDateTime(DateTime.UtcNow.AddYears(-3)),
                    Area = area
                }
            };
            //Act
            var listaDeFuncionariosOk = await distribuirLucrosService.DistribuirAsync(funcionarios);

            //Assert
            areaRepository.Find(area.Id).Should().NotBeNull();
            listaDeFuncionariosOk.Should().HaveCount(1);
        }

        [Fact]
        public async Task DeveValidarOsFuncionariosENaoPermitirNenhumaInsercaoForaDoPadraoDeValidacao() {
            //Arange
            var faker = new Faker("en");
            
            var distribuirLucrosService = ServiceProvider.GetService<IDistribuirLucrosService>();
            List<Funcionario> funcionarios = new (){};

            funcionarios.Add(new Funcionario(){
                    Nome = "",
                    Matricula = "",
                    SalarioBruto = -10,
                    DataDeAdimissao = faker.Date.FutureDateOnly(),
                    Cargo = ""
                });

            //Act
            var listaDeFuncionariosOk = await distribuirLucrosService.DistribuirAsync(funcionarios);
            var funcionariosBase = Context.Funcionario.ToList();

            //Assert
            funcionariosBase.Should().HaveCount(0); 
            listaDeFuncionariosOk.Should().HaveCount(0);     

        }
    }
}
