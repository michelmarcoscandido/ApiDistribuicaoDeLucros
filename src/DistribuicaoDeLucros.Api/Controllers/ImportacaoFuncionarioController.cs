using Microsoft.AspNetCore.Mvc;
using DistribuicaoDeLucros.Application.Response;
using DistribuicaoDeLucros.Application.Request;
namespace DistribuicaoDeLucros.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImportacaoFuncionarioController : ControllerBase
{
    
    [HttpPost]
    public async Task<IActionResult> Post(ParticipacaoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok("OK");
    }
}
