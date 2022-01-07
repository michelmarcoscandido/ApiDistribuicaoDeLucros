using System;
using System.Text.Json.Serialization;

namespace DistribuicaoDeLucros.Application.Response
{
    public class FuncionarioResponse
    {
        /// <summary>
        /// Matricula do Funcionário.
        /// </summary>
        public string Matricula { get; set; }
        /// <summary>
        /// Nome do Funcionário.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// Valor de participação que o Funcionário irá receber.
        /// </summary>
        [JsonPropertyName("valor_participacao")]
        public string ValorParticipacao { get; set; }
    }
}
