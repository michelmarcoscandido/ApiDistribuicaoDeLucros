using System;
using System.Globalization;
using AutoMapper;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Response;
using DistribuicaoDeLucros.Application.Services.Interfaces;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Services;

namespace DistribuicaoDeLucros.Application.Services
{
    public class DistribuirLucrosApplication : IDistribuirLucrosApplication
    {
        private readonly IDistribuirLucrosService distribuirLucrosService;
        private readonly IMapper mapper;

        public DistribuirLucrosApplication(IDistribuirLucrosService distribuirLucrosService, IMapper mapper)
        {
            this.distribuirLucrosService = distribuirLucrosService;
            this.mapper = mapper;
        }
        public async Task<ParticipacaoResponse> DistribuirAsync(ParticipacaoRequest participacao)
        {
            var funcionarios = mapper.Map<List<Funcionario>>(participacao.Funcionarios);
            var funcionariosComParticipacao = await distribuirLucrosService.DistribuirAsync(funcionarios);
            
            return new ParticipacaoResponse(){
                TotalDeFuncionarios = funcionariosComParticipacao.Count(),
                TotalDistribuido = string.Format(new CultureInfo("pt-br", false), "R$ {0:#,###.##}",funcionariosComParticipacao.Sum( x => x.ValorParticipacao)),
                Participacoes = mapper.Map<List<FuncionarioResponse>>(funcionariosComParticipacao)
            };
        }
    }
}
