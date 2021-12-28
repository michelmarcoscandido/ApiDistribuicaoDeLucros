using Microsoft.EntityFrameworkCore;
using DistribuicaoDeLucros.Domain.Entities;
namespace DistribuicaoDeLucros.Infra.Context
{
    public class SqlContext : DbContext
    {
        public DbSet<Area> Area { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
    }
}
