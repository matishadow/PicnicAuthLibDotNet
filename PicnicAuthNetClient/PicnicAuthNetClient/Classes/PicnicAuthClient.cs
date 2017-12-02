using System;
using PicnicAuthNetClient.Classes.Endpoints;
using RestSharp;

namespace PicnicAuthNetClient.Classes
{
    public class PicnicAuthClient
    {
        private readonly Uri baseEndpoint;

        private readonly AuthUsersEndpoint authUsersEndpoint;
        private readonly AuthUsersSecretsEndpoint authUsersSecretsEndpoint;
        private readonly CompaniesEndpoint companiesEndpoint;
        private readonly HotpsEndpoint hotpsEndpoint;
        private readonly TotpsEndpoint totpsEndpoint;

        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            IRestClient restClient = new RestClient(baseEndpoint);

            authUsersEndpoint = new AuthUsersEndpoint(restClient, apiKey);
            authUsersSecretsEndpoint = new AuthUsersSecretsEndpoint(restClient, apiKey);
            companiesEndpoint = new CompaniesEndpoint(restClient, apiKey);
            hotpsEndpoint = new HotpsEndpoint(restClient, apiKey);
            totpsEndpoint = new TotpsEndpoint(restClient, apiKey);
        }
    }
}