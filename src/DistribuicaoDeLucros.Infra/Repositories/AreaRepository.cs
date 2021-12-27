using DistribuicaoDeLucros.Domain.Entities;
using DistribuicaoDeLucros.Domain.Interfaces.Repositories;
using DistribuicaoDeLucros.Infra.Context;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Infra.Repositories
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        public AreaRepository(SqlContext dbContext) : base(dbContext)
        {
        }
    }
}
