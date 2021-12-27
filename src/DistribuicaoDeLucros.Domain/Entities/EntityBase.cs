using System.ComponentModel.DataAnnotations;

namespace DistribuicaoDeLucros.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
    }
}
