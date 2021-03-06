using System;
using DistribuicaoDeLucros.Domain.Entities;
using FluentValidation;

namespace DistribuicaoDeLucros.Services.Validator
{
    public class FuncionarioValidator : AbstractValidator<Funcionario>
    {
        
        public FuncionarioValidator()
        {
            RuleFor(x => x.Area).NotNull().SetValidator(new AreaValidator());
            RuleFor(x => x.Matricula).Length(3, 15).NotEmpty();
            RuleFor(x => x.Nome).Length(3, 100).NotEmpty();
            RuleFor(x => x.Cargo).Length(3, 50).NotEmpty();
            RuleFor(x => x.SalarioBruto).GreaterThan(0);
            RuleFor(x => x.DataDeAdimissao).NotNull()
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .GreaterThan(DateOnly.FromDateTime(DateTime.Today.AddYears(-100)));
        }
    }
}
