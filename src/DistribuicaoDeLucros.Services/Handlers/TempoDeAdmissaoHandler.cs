using System;
using DistribuicaoDeLucros.Services.Handlers;

namespace DistribuicaoDeLucros.Services.Handlers
{
    internal class TempoDeAdmissaoHandler : AbstractHandler
    {
        const int Peso1 = 1;
        const int Peso2 = 2;
        const int Peso3 = 3;
        const int Peso5 = 5;
        public override Participacao Handle(Participacao participacao)
        {

            var data = participacao.Funcionario.DataDeAdimissao;
            var dataAdimissao = new DateTime(data.Year, data.Month, data.Day);
            double anosDeAdimissao = (DateTime.UtcNow - dataAdimissao).TotalDays / 365;

            var peso = anosDeAdimissao switch {
                double anos when anos <= 1 => Peso1,
                double anos when anos > 1 && anos <= 3 => Peso2,
                double anos when anos > 3 && anos <= 8 => Peso3,
                double anos when anos > 8 => Peso5,
                _ => 0
            };

            participacao.PesoPortempoDeAdmissao = peso;
            return base.Handle(participacao);
        }
    }
}
