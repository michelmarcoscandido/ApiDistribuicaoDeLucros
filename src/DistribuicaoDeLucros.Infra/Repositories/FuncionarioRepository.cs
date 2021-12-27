using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Infra.Context;
using SE.EntityFrameworkCore.UnitOfWork;


namespace DistribuicaoDeLucros.Infra.Repositories
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(SqlContext dbContext) : base(dbContext)
        {
        }
    }
}
