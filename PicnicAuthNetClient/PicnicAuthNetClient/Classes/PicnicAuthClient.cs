using System;
using PicnicAuthNetClient.Classes.Endpoints;
using RestSharp;

namespace PicnicAuthNetClient.Classes
{
    public class PicnicAuthClient
    {
        private readonly Uri baseEndpoint;
        private readonly IRestClient restClient;

        private readonly AuthUsersEndpoint authUsersEndpoint;
        private readonly AuthUsersSecretsEndpoint authUsersSecretsEndpoint;
        private readonly CompaniesEndpoint companiesEndpoint;
        private readonly HotpsEndpoint hotpsEndpoint;

        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            restClient = new RestClient(baseEndpoint);

            authUsersEndpoint = new AuthUsersEndpoint(restClient, apiKey);
            authUsersSecretsEndpoint = new AuthUsersSecretsEndpoint(restClient, apiKey);
            companiesEndpoint = new CompaniesEndpoint(restClient, apiKey);
            hotpsEndpoint = new HotpsEndpoint(restClient, apiKey);
        }
    }
}