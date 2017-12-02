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

        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            restClient = new RestClient(baseEndpoint);

            authUsersEndpoint = new AuthUsersEndpoint(restClient, apiKey);
        }

        public IRestResponse AddCompany(string email, string userName, string password)
        {
            var request = new RestRequest("Companies", Method.POST);

            request.AddJsonBody(new
            {
                Email = email,
                UserName = userName,
                Password = password,
                ConfirmPassword = password
            });

            return restClient.Execute(request);
        }
    }
}