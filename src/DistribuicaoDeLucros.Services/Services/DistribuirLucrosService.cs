using System;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using DistribuicaoDeLucros.Services.Handlers;
using FluentValidation;
using Microsoft.Extensions.Logging;
using SE.EntityFrameworkCore.UnitOfWork;
using Serilog;

namespace DistribuicaoDeLucros.Services.Services
{
    public class DistribuirLucrosService : IDistribuirLucrosService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly AbstractValidator<Funcionario> funcionarioValidator;
        private readonly IAreaRepository areaRepository;

        public DistribuirLucrosService(
            IFuncionarioRepository funcionarioRepository, 
            IUnitOfWork unitOfWork, 
            AbstractValidator<Funcionario> funcionarioValidator,
            IAreaRepository areaRepository
            )
        {
            this.funcionarioRepository = funcionarioRepository;
            this.unitOfWork = unitOfWork;
            this.funcionarioValidator = funcionarioValidator;
            this.areaRepository = areaRepository;
        }

        public async Task<List<Funcionario>> DistribuirAsync(List<Funcionario> funcionarios)
        {
            var funcionariosValidos = new List<Funcionario>();
            foreach(Funcionario funcionario in funcionarios) {
                var valicaoFuncionario = funcionarioValidator.Validate(funcionario);
                if(valicaoFuncionario.IsValid) {
                    var area = areaRepository.GetFirstOrDefault(predicate: p => p.Descricao.Equals(funcionario.Area.Descricao), disableTracking: false);
                    if(area is not null) {
                        funcionario.Area = area;
                        funcionario.ValorParticipacao = ObterValorParticipacao(funcionario);
                        funcionariosValidos.Add(funcionario);
                        await funcionarioRepository.InsertAsync(funcionario);
                    } else {
                        Log.Debug("Houve um erro para calcular a participacao do Funcionário: {@Funcionario} Erro: Area não encontrada", funcionario);
                    }
                } else {
                    Log.Debug("Houve um erro para calcular a participacao do Funcionário: {@Funcionario} Erro: {@Erro}", funcionario, valicaoFuncionario.Errors);
                }
            }
            await unitOfWork.SaveChangesAsync();
            return funcionariosValidos;
        }

        private decimal ObterValorParticipacao(Funcionario funcionario) {
            var areaDeAtuacao = new AreaDeAtuacaoHandler();
            areaDeAtuacao
            .SetNext(new FaixaSalarialHandler())
            .SetNext(new TempoDeAdmissaoHandler())
            .SetNext(new CalcularParticipacaoHandler());

            var retornoParticipacao = areaDeAtuacao.Handle(new Participacao(){
                Funcionario = funcionario
            });

            return retornoParticipacao.ValorParticipacao;
        }
    }
}
