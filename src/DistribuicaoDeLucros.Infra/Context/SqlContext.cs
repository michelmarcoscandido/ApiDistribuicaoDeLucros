using System;
using Microsoft.EntityFrameworkCore;

namespace DistribuicaoDeLucros.Infra.Context
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
            
        }
    }
}
