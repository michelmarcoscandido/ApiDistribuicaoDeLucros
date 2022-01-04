using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DistribuicaoDeLucros.Api.Controllers;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Response;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq.AutoMock;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario.Controller
{
    public class ImportacaoFuncionarioControllerTests
    {
        [Fact]
        public async Task DeveRetornarStatusObjetoActionResultOk()
        {

            var controller = new ImportacaoFuncionarioController();
            var mocker = new AutoMocker();   
            var funcionarios = new ParticipacaoRequest(){
                Funcionarios = new List<FuncionarioRequest>(){
                    new(){
                        Nome = "Funcionario",
                        Matricula = "123123",
                        Area = "AREA",
                        Cargo = "Cargo",
                        SalarioBruto = 1,
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

            var controller = new ImportacaoFuncionarioController();
            controller.ModelState.AddModelError("Matricula", "Required");
            var funcionarios = new ParticipacaoRequest();

            // Act
            var result = await controller.Post(funcionarios);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            

        }
    }
}
