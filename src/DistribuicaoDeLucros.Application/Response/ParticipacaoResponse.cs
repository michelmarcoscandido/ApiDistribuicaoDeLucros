using System;
using System.Text.Json.Serialization;

namespace DistribuicaoDeLucros.Application.Response
{
    public class ParticipacaoResponse
    {
        /// <summary>
        /// Funcionários que terão participação.
        /// </summary>
        public List<FuncionarioResponse> Participacoes { get; set; }
        /// <summary>
        /// Quantidade total de Funcionários.
        /// </summary>
        [JsonPropertyName("total_de_funcionarios")]
        public int TotalDeFuncionarios { get; set; }
        /// <summary>
        /// Total que será distribuido entre os funcionários.
        /// </summary>
        [JsonPropertyName("total_distribuido")]
        public string TotalDistribuido {get; set; }
    }
}
