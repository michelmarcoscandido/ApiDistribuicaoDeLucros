using System;
using System.Runtime.CompilerServices;
using DistribuicaoDeLucros.Services.Handlers;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Services.Handlers
{
    internal class AreaDeAtuacaoHandler : AbstractHandler
    {
        public override Participacao Handle(Participacao participacao)
        {
            participacao.PesoPorAreaDeAtuacao = participacao.Funcionario.Area.Peso;
            return base.Handle(participacao);
        }
    }
}
