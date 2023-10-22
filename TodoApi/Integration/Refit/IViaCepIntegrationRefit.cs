using Refit;
using TodoApi.Integration.Response;

namespace TodoApi.Integration.Refit
{
    public interface IViaCepIntegrationRefit
    {
        [Get("/ws/{cep}/json")]
        Task<ApiResponse<ViaCepResponse>> GetDataViaCep(string cep);
    }
}
