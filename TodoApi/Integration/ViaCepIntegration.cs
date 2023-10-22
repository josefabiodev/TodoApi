using TodoApi.Integration.Interfaces;
using TodoApi.Integration.Refit;
using TodoApi.Integration.Response;

namespace TodoApi.Integration
{
    public class ViaCepIntegration : IViaCepIntegration
    {
        private readonly IViaCepIntegrationRefit _viaCepIntegrationRefit;

        public ViaCepIntegration(IViaCepIntegrationRefit viaCepIntegrationRefit)
        {
            _viaCepIntegrationRefit = viaCepIntegrationRefit;
        }

        public async Task<ViaCepResponse> GetDataViaCep(string cep)
        {
            var responseData = await _viaCepIntegrationRefit.GetDataViaCep(cep);

            if (responseData != null && responseData.IsSuccessStatusCode)
            {
                return responseData.Content;
            }
            return null;
        }
    }
}
