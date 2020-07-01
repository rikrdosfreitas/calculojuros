using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Juros.Application.Service
{
    public interface IApiService
    {
        Task<decimal> GetTaxaJuros();
    }

    public class ApiService : ApiServiceBase, IApiService
    {
        public ApiService(IHttpClientFactory clientFactory, string UrlBase) : base(clientFactory, UrlBase)
        {
        }

        public async Task<decimal> GetTaxaJuros()
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, "/api/taxaJuros"))
            using (var client = GetClient())
            using (var response = await client.SendAsync(request))
            {
                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var value = Decimal.Parse(contentResponse);
                    return value;
                }

                throw new HttpRequestException(contentResponse);
            }
        }

      
    }

    public abstract class ApiServiceBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _urlBase;

        protected ApiServiceBase(IHttpClientFactory clientFactory, string UrlBase)
        {
            _clientFactory = clientFactory;
            _urlBase = UrlBase;
        }

        protected HttpClient GetClient()
        {
            HttpClient client = _clientFactory.CreateClient();
            client.BaseAddress = new Uri(_urlBase);

            return client;
        }
    }
}
