using System;
using DistribuicaoDeLucros.Domain.Entities;

namespace DistribuicaoDeLucros.Domain.Interfaces.Services
{
    public interface IDistribuirLucrosService
    {
        Task<List<Funcionario>> DistribuirAsync(List<Funcionario> funcionarios); 
    }
}
