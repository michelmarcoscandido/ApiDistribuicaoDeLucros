using System;

namespace DistribuicaoDeLucros.Domain.Entities
{
    public class Funcionario
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public Area Area { get; set; }
        public string Cargo { get; set; }
        public decimal SalarioBruto { get; set; }
        public DateOnly DataDeAdimissao { get; set; }
    }

    
}
