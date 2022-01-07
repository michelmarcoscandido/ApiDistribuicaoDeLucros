using Microsoft.AspNetCore.Mvc;
using DistribuicaoDeLucros.Application.Response;
using DistribuicaoDeLucros.Application.Request;
using DistribuicaoDeLucros.Application.Services.Interfaces;

namespace DistribuicaoDeLucros.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImportacaoFuncionarioController : ControllerBase
{
    private readonly IDistribuirLucrosApplication distribuirLucrosService;

    public ImportacaoFuncionarioController(IDistribuirLucrosApplication distribuirLucrosService)
    {
        this.distribuirLucrosService = distribuirLucrosService;
    }
    [HttpPost]
    public async Task<IActionResult> Post(ParticipacaoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok(await distribuirLucrosService.DistribuirAsync(request));

    }
}
