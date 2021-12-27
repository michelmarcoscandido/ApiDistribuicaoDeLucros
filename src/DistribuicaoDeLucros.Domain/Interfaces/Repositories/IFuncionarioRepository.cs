using System;
using DistribuicaoDeLucros.Domain.Entities;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository  : IRepository<Funcionario>
    {
    }
}
