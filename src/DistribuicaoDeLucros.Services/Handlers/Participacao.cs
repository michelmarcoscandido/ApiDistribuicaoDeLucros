using System;
using System.Runtime.CompilerServices;
using DistribuicaoDeLucros.Domain.Entities;

[assembly: InternalsVisibleTo("DistribuicaoDeLucros.Test.Unitario")]
namespace DistribuicaoDeLucros.Services.Handlers
{
    internal class Participacao
    {
        public Funcionario Funcionario { get; set; }
        public int PesoPorAreaDeAtuacao { get; set; }
        public int PesoPorFaixaSalarial { get; set; }
        public int PesoPortempoDeAdmissao { get; set; }
        public decimal ValorParticipacao { get; set; }
        
    }
}
