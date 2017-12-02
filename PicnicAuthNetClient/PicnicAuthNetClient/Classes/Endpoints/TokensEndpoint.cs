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
            var request = new RestRequest("Companies/Me/AuthUsers", Method.POST);

            request.AddQueryParameter(nameof(grant_type), grant_type);
            request.AddQueryParameter(nameof(username), username);
            request.AddQueryParameter(nameof(password), password);

            return restClient.Execute<TokenResponse>(request);
        }
    }
}
