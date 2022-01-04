using System;

namespace DistribuicaoDeLucros.Application.Request
{
    public class ParticipacaoRequest
    {
        /// <summary>
        /// Lista de Funcionário.
        ///</summary>
        public List<FuncionarioRequest> Funcionarios { get; set; }
    }
}
