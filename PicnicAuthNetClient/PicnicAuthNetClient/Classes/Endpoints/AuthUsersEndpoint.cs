using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class AuthUsersEndpoint : AuthorizedEndpoint
    {
        private readonly IRestClient restClient;
        private readonly string apiKey;

        public AuthUsersEndpoint(IRestClient restClient, string apiKey)
        {
            this.restClient = restClient;
            this.apiKey = apiKey;
        }

        public IRestResponse<AuthUsersInCompany> 
            GetAuthUsersForLoggedCompany(int page = 1, int pageCount = 10)
        {
            var request = new RestRequest("Companies/Me/AuthUsers", Method.GET);
            AddAuthorizationHeader(request, apiKey);

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter(nameof(pageCount), pageCount.ToString());

            return restClient.Execute<AuthUsersInCompany>(request);
        }

        public IRestResponse<CreatedAuthUser> AddAuthUser(AddAuthUserArgument addAuthUserArgument)
        {
            var request = new RestRequest("AuthUsers", Method.POST);
            AddAuthorizationHeader(request, apiKey);

            request.AddJsonBody(addAuthUserArgument);

            return restClient.Execute<CreatedAuthUser>(request);
        }
    }
}