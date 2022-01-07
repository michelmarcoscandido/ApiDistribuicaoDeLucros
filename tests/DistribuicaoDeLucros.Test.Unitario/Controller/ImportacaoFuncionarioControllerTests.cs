using System.Collections.Generic;
using System.Threading.Tasks;
using DistribuicaoDeLucros.Api.Controllers;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Response;
using DistribuicaoDeLucros.Application.Services.Interfaces;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario.Controller
{
    public class ImportacaoFuncionarioControllerTests : BaseTests
    {
        [Fact]
        public async Task DeveRetornarStatusObjetoActionResultOk()
        {
            

            var distribuirLucrosService = ServiceProvider.GetService<IDistribuirLucrosApplication>();   
            var controller = new ImportacaoFuncionarioController(distribuirLucrosService);
            var funcionarios = new ParticipacaoRequest(){
                Funcionarios = new List<FuncionarioRequest>(){
                    new(){
                        Nome = "Funcionario",
                        Matricula = "123123",
                        Area = "Diretoria",
                        Cargo = "Cargo",
                        SalarioBruto = "R$ 1,00",
                        DataDeAdimissao = "2019-01-01"
                    }
                }
            };
            

            // Act
            var result = await controller.Post(funcionarios);
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task DeveRetornarObjetoActionResultBadRequestPoisPossioModelStateError()
        {

            var distribuirLucrosService = ServiceProvider.GetService<IDistribuirLucrosApplication>();   
            var controller = new ImportacaoFuncionarioController(distribuirLucrosService);
            controller.ModelState.AddModelError("Matricula", "Required");
            var funcionarios = new ParticipacaoRequest();

            // Act
            var result = await controller.Post(funcionarios);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            

        }
    }
}
