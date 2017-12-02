using System;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class TotpsEndpoint : AuthorizedEndpoint
    {
        public TotpsEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }

        public IRestResponse<OneTimePassword> GetTotpForAuthUser(Guid userId)
        {
            var request = new RestRequest($"AuthUsers/{userId}/totp", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<OneTimePassword>(request);
        }

        public IRestResponse<OtpValidationResult> ValidateTotpForAuthUser(Guid userId, string totp)
        {
            var request = new RestRequest($"AuthUsers/{userId}/totp/{totp}", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<OtpValidationResult>(request);
        }
    }
}