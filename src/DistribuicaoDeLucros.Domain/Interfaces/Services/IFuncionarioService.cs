using System;
using DistribuicaoDeLucros.Domain.Entities;

namespace DistribuicaoDeLucros.Domain.Interfaces.Services
{
    public interface IFuncionarioService
    {
        Task ArmazenarFuncionariosAsync(List<Funcionario> funcionarios); 
    }
}
