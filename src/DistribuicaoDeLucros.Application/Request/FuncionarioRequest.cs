using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DistribuicaoDeLucros.Application.Request
{
    public class FuncionarioRequest
    {
        /// <summary>
        /// Matricula do Funcionário. Deve conter de 3 a 15 caracteres
        /// </summary>
        [Required]
        public string Matricula { get; set; }
        /// <summary>
        /// Nome do Funcionário. Deve conter de 3 a 100 caracteres
        /// </summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>
        /// Area do Funcionário. Deve ser Diretoria, Contabilidade, Financeiro, Tecnologia, Serviços Gerais ou Relacionamento com o Cliente 
        /// </summary>
        [Required]
        public string Area { get; set; }
        /// <summary>
        /// Cargo do Funcionário. Deve conter de 3 a 50 caracteres
        /// </summary>
        [Required]
        public string Cargo { get; set; }
        /// <summary>
        /// Salário Bruto do Funcionário. Deve ser superior a R$ 0,00
        /// </summary>
        [JsonPropertyName("salario_bruto")]
        [Required]
        public string SalarioBruto { get; set; }
        /// <summary>
        /// Data de Admissão do Funcionário. Deve igual ou inferior a data atual.
        /// </summary>
        [JsonPropertyName("data_de_adimissao")]
        [Required]
        public string DataDeAdimissao { get; set; }
    }
}
