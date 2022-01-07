using System;
using DistribuicaoDeLucros.Domain.Entities;
using FluentValidation;

namespace DistribuicaoDeLucros.Services.Validator
{
    public class AreaValidator : AbstractValidator<Area>
    {
        public AreaValidator()
        {
            RuleFor(x => x.Descricao).Length(3, 100).NotEmpty();
        }
    }
}
