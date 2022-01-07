using System;
using System.Globalization;
using AutoMapper;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Response;
using DistribuicaoDeLucros.Application.Services;
using DistribuicaoDeLucros.Application.Services.Interfaces;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Infra.Context;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoDeLucros.Application
{
    public static class ApplicationDependencyLoader
    {
         public static void LoadApplicationDependencyLoader(this IServiceCollection services) {
            services.AddScoped<IDistribuirLucrosApplication, DistribuirLucrosApplication>();;   
            
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<FuncionarioRequest, Funcionario>()
                    .ForMember(dst => dst.Area, map => {
                        map.PreCondition(src => !string.IsNullOrEmpty(src.Area));
                        map.MapFrom(src => new Area(){Descricao = src.Area, Peso = 0});
                    })
                    .ForMember(dst => dst.SalarioBruto, map => map.MapFrom(src => decimal.Parse(src.SalarioBruto, NumberStyles.Currency, new CultureInfo("pt-br"))))
                    .ForMember(dst => dst.DataDeAdimissao, map => map.MapFrom(src => DateOnly.FromDateTime(DateTime.Parse(src.DataDeAdimissao))));

                cfg.CreateMap<Funcionario, FuncionarioResponse>()
                .ForMember(dst => dst.ValorParticipacao, map => map.MapFrom(src => string.Format(new CultureInfo("pt-br", false), "R$ {0:#,###.##}", src.ValorParticipacao)));
            });

            IMapper mapper = configuration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
