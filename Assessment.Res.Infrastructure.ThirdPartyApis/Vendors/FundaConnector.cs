using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Assessment.Res.Infrastructure.ThirdPartyApis.Vendors
{
    public class FundaConnector: IFundaConnector
    {
        private readonly IOptions<FundaApiConfig> _fundaApiConfig;
        private readonly IHttpClientFactory _httpClientFactory;

        public FundaConnector(IOptions<FundaApiConfig> fundaApiConfig, IHttpClientFactory httpClientFactory)
        {
            _fundaApiConfig = fundaApiConfig;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FundaGetOffersResponse> GetOffersAsync(int page, bool withGarden)
        {
            var baseUrl = _fundaApiConfig.Value.FundaApiUrl;

            var requestUrl = baseUrl.Replace("[key]", _fundaApiConfig.Value.FundaKey)
                .Replace("[zo]", withGarden ? "/amsterdam/tuin/" : "/amsterdam/")
                .Replace("[page]", page.ToString());

            return await GetAsync<FundaGetOffersResponse>(requestUrl);
        }

        private async Task<TResponse> GetAsync<TResponse>(string callEndpoint)
        {
            using (var client = _httpClientFactory.CreateClient("funda"))
            {
                var requestMsg = new HttpRequestMessage(HttpMethod.Get, callEndpoint);

                var message = await client.SendAsync(requestMsg);

                message.EnsureSuccessStatusCode();

                return await DeserializeResponseAsync<TResponse>(message);
            }
        }

        private static async Task<T> DeserializeResponseAsync<T>(HttpResponseMessage responseMessage)
        {
            using var jsonStream = await responseMessage.Content.ReadAsStreamAsync();
            var obj = await JsonSerializer.DeserializeAsync<T>(jsonStream);
            return obj;
        }
    }
}
