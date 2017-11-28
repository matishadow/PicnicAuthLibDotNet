using System;
using RestSharp;

namespace PicnicAuthNetClient.Classes
{
    public class PicnicAuthClient
    {
        private readonly Uri baseEndpoint;
        private readonly string apiKey;
        private readonly IRestClient restClient;

        private const string AuthenticationHeaderName = "Authorization";
        private const string AuthenticationHeaderValueFormat = "Bearer {0}";


        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            this.baseEndpoint = baseEndpoint;
            this.apiKey = apiKey;
            restClient = new RestClient(baseEndpoint);
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

        private void AddAuthorizationHeader(IRestRequest request)
        {
            request?.AddHeader(AuthenticationHeaderName, string.Format(AuthenticationHeaderValueFormat, apiKey));
        }
    }
}