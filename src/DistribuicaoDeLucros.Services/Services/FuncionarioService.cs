using System;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using FluentValidation;
using SE.EntityFrameworkCore.UnitOfWork;

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
                if(funcionarioValidator.Validate(funcionario).IsValid) {
                    await funcionarioRepository.InsertAsync(funcionario);
                }
            });
            await unitOfWork.SaveChangesAsync();
        }
    }
}
