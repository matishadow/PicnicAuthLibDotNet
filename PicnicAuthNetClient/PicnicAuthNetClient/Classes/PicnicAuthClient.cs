using System;
using PicnicAuthNetClient.Classes.Endpoints;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes
{
    public class PicnicAuthClient
    {
        private readonly IRestClient restClient;
        private string apiKey;

        private AuthUsersEndpoint authUsersEndpoint;
        private AuthUsersSecretsEndpoint authUsersSecretsEndpoint;
        private CompaniesEndpoint companiesEndpoint;
        private HotpsEndpoint hotpsEndpoint;
        private TotpsEndpoint totpsEndpoint;
        private TokensEndpoint tokensEndpoint;

        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            restClient = new RestClient(baseEndpoint);
            this.apiKey = apiKey;
            CreateEndpoints();
        }

        private void CreateEndpoints()
        {
            authUsersEndpoint = new AuthUsersEndpoint(restClient, apiKey);
            authUsersSecretsEndpoint = new AuthUsersSecretsEndpoint(restClient, apiKey);
            companiesEndpoint = new CompaniesEndpoint(restClient, apiKey);
            hotpsEndpoint = new HotpsEndpoint(restClient, apiKey);
            totpsEndpoint = new TotpsEndpoint(restClient, apiKey);
            tokensEndpoint = new TokensEndpoint(restClient);
        }

        public IRestResponse<TokenResponse> Login(string username, string password)
        {
            IRestResponse<TokenResponse> response = tokensEndpoint.GetApiKey(username, password);
            apiKey = response.Data.access_token;
            CreateEndpoints();

            return response;
        }
    }
}