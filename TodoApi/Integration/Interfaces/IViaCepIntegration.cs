using TodoApi.Integration.Response;

namespace TodoApi.Integration.Interfaces
{
    public interface IViaCepIntegration
    {
        Task<ViaCepResponse> GetDataViaCep(string cep);
    }
}
