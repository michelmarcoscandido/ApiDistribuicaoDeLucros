using System;
using System.ComponentModel.DataAnnotations;

namespace DistribuicaoDeLucros.Domain.Entities
{
    public class Funcionario : EntityBase
    {
        [Required]
        [MaxLength(15)]
        public string Matricula { get; set; }
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }
        [Required]
        public Area Area { get; set; }
        [Required]
        [MaxLength(50)]
        public string Cargo { get; set; }
        [Required]
        public decimal SalarioBruto { get; set; }
        [Required]
        public DateOnly DataDeAdimissao { get; set; }
    }

    
}
