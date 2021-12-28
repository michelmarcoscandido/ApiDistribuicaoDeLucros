using System;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using DistribuicaoDeLucros.Services.Services;
using DistribuicaoDeLucros.Services.Validator;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoDeLucros.Services
{
    public static class ServiceDependencyLoader
    {
        public static void LoadServiceDependencyLoader(this IServiceCollection services) {
            services.AddScoped<IFuncionarioService, FuncionarioService>();
            services.AddScoped<AbstractValidator<Funcionario>, FuncionarioValidator>();
        }
    }
}
