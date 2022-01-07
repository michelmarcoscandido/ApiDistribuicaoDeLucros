using System;
using DistribuicaoDeLucros.Application;
using DistribuicaoDeLucros.Infra;
using DistribuicaoDeLucros.Infra.Context;
using DistribuicaoDeLucros.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SE.EntityFrameworkCore.UnitOfWork;

namespace DistribuicaoDeLucros.Test.Unitario
{
    abstract public class BaseTests : IDisposable
    {
        public BaseTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.LoadInfraDependencyLoader();
            serviceCollection.LoadServiceDependencyLoader();
            serviceCollection.LoadApplicationDependencyLoader();

            serviceCollection.AddDbContext<SqlContext>( opt => opt.UseInMemoryDatabase(Guid.NewGuid().ToString()))
            .AddUnitOfWork<SqlContext>();

            ServiceProvider = serviceCollection.BuildServiceProvider();


            Context = ServiceProvider.GetService<SqlContext>();

        }

        protected readonly SqlContext Context;
        protected readonly ServiceProvider ServiceProvider;
        
        public void Dispose()
        {
            //this has no effect 
            if (Context != null)
            {                
                Context.Database.EnsureDeleted();
                Context.SaveChanges();
                Context.Dispose();
            }
        }
    }



}
