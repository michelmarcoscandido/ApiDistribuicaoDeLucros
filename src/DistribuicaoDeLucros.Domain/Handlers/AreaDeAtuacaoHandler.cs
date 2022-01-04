using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Domain.Handlers
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
