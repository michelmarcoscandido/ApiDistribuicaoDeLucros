using System;
using DistribuicaoDeLucros.Services.Handlers;

namespace DistribuicaoDeLucros.Services.Handlers
{
    internal class FaixaSalarialHandler : AbstractHandler
    {
        const int Peso1 = 1;
        const int Peso3 = 3;
        const int Peso5 = 5;
        public override Participacao Handle(Participacao participacao)
        {

            var peso = participacao.Funcionario.SalarioBruto switch {
                decimal salario when salario <= 2000 => Peso1,
                decimal salario when salario > 2000 && salario <= 7000 => Peso3,
                decimal salario when salario > 7000 => Peso5,
                _ => 0
            };
            participacao.PesoPorFaixaSalarial = peso;
            return base.Handle(participacao);
        }
    }
}
