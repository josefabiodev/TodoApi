using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Integration.Interfaces;
using TodoApi.Integration.Response;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CepController : ControllerBase
    {
        private readonly IViaCepIntegration _viaCepIntegration;

        public CepController(IViaCepIntegration viaCepIntegration)
        {
            _viaCepIntegration = viaCepIntegration;
        }

        [HttpGet("{cep}")]
        public async Task<ActionResult<ViaCepResponse>> ListDataAddress(string cep)
        {
            var responseData = await _viaCepIntegration.GetDataViaCep(cep);
            if (responseData == null)
            {
                return BadRequest("CEP não encontrado");
            }
            return Ok(responseData);
        }
    }
}
