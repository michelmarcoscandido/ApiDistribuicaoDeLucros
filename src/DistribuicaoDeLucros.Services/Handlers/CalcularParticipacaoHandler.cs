using System;
using System.Runtime.CompilerServices;
using DistribuicaoDeLucros.Services.Handlers;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Services.Handlers
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
                participacao.ValorParticipacao = Math.Round(resultado, 2);

            return participacao;
        }
    }
}
