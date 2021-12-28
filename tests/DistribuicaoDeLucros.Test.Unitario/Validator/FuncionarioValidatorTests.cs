using System;
using System.Linq;
using Bogus;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Infra.Context;
using FluentValidation;
using FluentValidation.TestHelper;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DistribuicaoDeLucros.Test.Unitario.Validator
{
    public class FuncionarioValidatorTests : BaseTests
    {
        [Fact]
        public void DeveHaverErroQuandoOsDadosDoFuncionarioEstaoTodosNulos() 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {};
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Matricula);
            result.ShouldHaveValidationErrorFor(person => person.Area);
            result.ShouldHaveValidationErrorFor(person => person.Cargo);
            result.ShouldHaveValidationErrorFor(person => person.DataDeAdimissao);
            result.ShouldHaveValidationErrorFor(person => person.Nome);
            result.ShouldHaveValidationErrorFor(person => person.SalarioBruto);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ab")]
        [InlineData("123456789101112131415")]
        public void DeveHaverErroQuandoAMatriculaEstaVaziaOuForaDosLimitesMinimoEMaximo(string matricula) 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {
                Matricula = matricula
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Matricula);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ab")]
        [InlineData("123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415")]
        public void DeveHaverErroQuandoOCargoEstaVazioOuForaDosLimitesMinimoEMaximo(string cargo) 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {
                Cargo = cargo
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Cargo);
        }

        [Fact]
        public void DeveHaverErroQuandoADataDeEmissaoEstaNoFuturo() 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {
                DataDeAdimissao = DateOnly.FromDateTime(DateTime.Today.AddDays(1))
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.DataDeAdimissao);
        }

        [Theory]
        [InlineData("")]
        [InlineData("ab")]
        [InlineData("123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415123456789101112131415")]
        public void DeveHaverErroQuandoONomeEstaVazioOuForaDosLimitesMinimoEMaximo(string nome) 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {
                Nome = nome
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.Nome);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void DeveHaverErroQuandoOSalarioBrutoEInferiorOuIgualAZero(decimal salarioBruto) 
        {
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var model = new Funcionario () {
                SalarioBruto = salarioBruto
            };
            var result = validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(person => person.SalarioBruto);
        }

        [Fact]
        public void DeveEstarTudoOkQuandoOsDadosDoFuncionarioEstaoPreenchidosCorretamente() 
        {

            //Arange
            using var context = ServiceProvider.GetService<SqlContext>();
            var area = context.Area.FirstOrDefault();
            
            
            var validator = ServiceProvider.GetService<AbstractValidator<Funcionario>>();

            var faker = new Faker("en");
            var model = new Funcionario () {
                Nome = faker.Person.FullName,
                Matricula = faker.Random.AlphaNumeric(10),
                Cargo = faker.Name.JobArea(),
                SalarioBruto = faker.Random.Decimal(1000.62m, 5982.23m),
                DataDeAdimissao = faker.Date.PastDateOnly(),
                Area = area    
            };
            var result = validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(person => person.Matricula);
            result.ShouldNotHaveValidationErrorFor(person => person.Area);
            result.ShouldNotHaveValidationErrorFor(person => person.Cargo);
            result.ShouldNotHaveValidationErrorFor(person => person.DataDeAdimissao);
            result.ShouldNotHaveValidationErrorFor(person => person.Nome);
            result.ShouldNotHaveValidationErrorFor(person => person.SalarioBruto);
        }
    }
}
