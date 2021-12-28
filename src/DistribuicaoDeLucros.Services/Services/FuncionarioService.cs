using System;
using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Domain.Interfaces.Services;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Services.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository funcionarioRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAreaRepository areaRepository;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, IUnitOfWork unitOfWork)
        {
            this.funcionarioRepository = funcionarioRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task ArmazenarFuncionarios(List<Funcionario> funcionarios)
        {
            await funcionarioRepository.InsertAsync(funcionarios);
            await unitOfWork.SaveChangesAsync();
        }
    }
}
