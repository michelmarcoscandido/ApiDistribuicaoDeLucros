using System;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Domain.Handlers
{
    internal class CalcularParticipacaoHandler : AbstractHandler
    {

        public override Participacao Handle(Participacao participacao)
        {

            	decimal salarioBruto = participacao.Funcionario.SalarioBruto;
                int pesoPorTempoDeTrabalho = participacao.PesoPortempoDeAdmissao;
                int pesoPorAreaDeAtuacao = participacao.PesoPorAreaDeAtuacao;
                int pesoPorFaixaSalarial = participacao.PesoPorFaixaSalarial;
                

                decimal resultado = ((pesoPorTempoDeTrabalho + pesoPorAreaDeAtuacao) * salarioBruto * 3) / pesoPorFaixaSalarial;
                participacao.ValorDaParticipacao = Math.Round(resultado, 2);

            return participacao;
        }
    }
}
