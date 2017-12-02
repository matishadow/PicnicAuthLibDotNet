using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class TokensEndpoint
    {
        private readonly IRestClient restClient;
        private const string grant_type = "password";

        public TokensEndpoint(IRestClient restClient)
        {
            this.restClient = restClient;
        }

        public IRestResponse<TokenResponse> GetApiKey(string username, string password)
        {
            var request = new RestRequest("tokens", Method.POST);

            request.AddParameter(nameof(grant_type), grant_type);
            request.AddParameter(nameof(username), username);
            request.AddParameter(nameof(password), password);

            return restClient.Execute<TokenResponse>(request);
        }
    }
}
