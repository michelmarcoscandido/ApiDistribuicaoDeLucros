using System;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Response;

namespace DistribuicaoDeLucros.Application.Services.Interfaces
{
    public interface IDistribuirLucrosApplication
    {
        Task<ParticipacaoResponse> DistribuirAsync(ParticipacaoRequest participacao);
    }
}
