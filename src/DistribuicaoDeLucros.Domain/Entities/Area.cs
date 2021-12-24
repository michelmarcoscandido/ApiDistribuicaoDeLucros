using System;

namespace DistribuicaoDeLucros.Domain.Entities
{
    public class Area
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Descricao { get; set; }
    }
}
