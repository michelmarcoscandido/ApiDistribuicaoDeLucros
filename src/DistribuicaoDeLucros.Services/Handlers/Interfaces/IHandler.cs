using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Services.Handlers.Interfaces
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Participacao Handle(Participacao participacao);
    }
}
