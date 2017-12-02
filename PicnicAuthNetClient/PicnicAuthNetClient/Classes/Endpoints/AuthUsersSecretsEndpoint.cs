using System;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class AuthUsersSecretsEndpoint : AuthorizedEndpoint
    {
        public AuthUsersSecretsEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }

        public IRestResponse<CreatedAuthUser> GenereteNewSecret(Guid userId)
        {
            var request = new RestRequest($"AuthUsers/{userId}/secret", Method.PATCH);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<CreatedAuthUser>(request);
        }
    }
}