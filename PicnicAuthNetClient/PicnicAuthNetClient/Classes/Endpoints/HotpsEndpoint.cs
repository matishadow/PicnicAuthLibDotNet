using System;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class HotpsEndpoint : AuthorizedEndpoint
    {
        public HotpsEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }

        public IRestResponse<OneTimePassword> GetHotpForAuthUser(Guid userId)
        {
            var request = new RestRequest($"AuthUsers/{userId}/hotp", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<OneTimePassword>(request);
        }

        public IRestResponse<OtpValidationResult> ValidateHotpForAuthUser(Guid userId, string hotp)
        {
            var request = new RestRequest($"AuthUsers/{userId}/hotp/{hotp}", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<OtpValidationResult>(request);
        }
    }
}