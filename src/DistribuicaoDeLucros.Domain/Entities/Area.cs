using System.ComponentModel.DataAnnotations;

namespace DistribuicaoDeLucros.Domain.Entities
{
    public class Area : EntityBase
    {

        [Required]
        public string Descricao { get; set; }
    }
}
