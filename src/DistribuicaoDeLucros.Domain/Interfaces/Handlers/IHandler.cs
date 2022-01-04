using System.Runtime.CompilerServices;
using DistribuicaoDeLucros.Domain.Handlers;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Domain.Interfaces.Handlers
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        Participacao Handle(Participacao participacao);
    }
}
