using System;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using FluentValidation;
using SE.EntityFrameworkCore.UnitOfWork;
using Serilog;

namespace DistribuicaoDeLucros.Services.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly AbstractValidator<Funcionario> funcionarioValidator;
        private readonly IAreaRepository areaRepository;

        public FuncionarioService(
            IFuncionarioRepository funcionarioRepository, 
            IUnitOfWork unitOfWork, 
            AbstractValidator<Funcionario> funcionarioValidator)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.unitOfWork = unitOfWork;
            this.funcionarioValidator = funcionarioValidator;
        }

        public async Task ArmazenarFuncionariosAsync(List<Funcionario> funcionarios)
        {

            funcionarios.ForEach(async funcionario => {
                var valicaoFuncionario = funcionarioValidator.Validate(funcionario);
                if(valicaoFuncionario.IsValid) {
                    await funcionarioRepository.InsertAsync(funcionario);
                } else {
                    Log.Information("Houve um erro para inserir em nossa base dados o Funcionário: {@Funcionario} Erro: {@Erro}", funcionario, valicaoFuncionario.Errors);
                }
            });
            await unitOfWork.SaveChangesAsync();
        }
    }
}
