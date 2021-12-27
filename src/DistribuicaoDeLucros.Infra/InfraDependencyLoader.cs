using System;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Infra.Context;
using DistribuicaoDeLucros.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Infra
{
    public static class InfraDependencyLoader
    {
        public static void LoadInfraDependencyLoader(this IServiceCollection services) {
            services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            services.AddScoped<IAreaRepository, AreaRepository>();

            services.AddDbContext<SqlContext>( opt => opt.UseInMemoryDatabase("DistribuicaoDeLucros"))
            .AddUnitOfWork<SqlContext>();
        }
    }
}
