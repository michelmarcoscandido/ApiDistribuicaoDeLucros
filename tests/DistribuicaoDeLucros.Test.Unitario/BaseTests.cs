using System;
using DistribuicaoDeLucros.Infra;
using DistribuicaoDeLucros.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DistribuicaoDeLucros.Test.Unitario
{
    abstract public class BaseTests
    {
    public BaseTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.LoadInfraDependencyLoader();
        serviceCollection.LoadServiceDependencyLoader();

        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
    protected readonly ServiceProvider ServiceProvider;

    }
}
