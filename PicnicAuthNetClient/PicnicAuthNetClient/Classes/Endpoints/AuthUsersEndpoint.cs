using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class AuthUsersEndpoint : AuthorizedEndpoint
    {
        public AuthUsersEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }

        public IRestResponse<AuthUsersInCompany> 
            GetAuthUsersForLoggedCompany(int page = 1, int pageCount = 10)
        {
            var request = new RestRequest("Companies/Me/AuthUsers", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            request.AddQueryParameter(nameof(page), page.ToString());
            request.AddQueryParameter(nameof(pageCount), pageCount.ToString());

            return RestClient.Execute<AuthUsersInCompany>(request);
        }

        public IRestResponse<CreatedAuthUser> AddAuthUser(AddAuthUserArgument addAuthUserArgument)
        {
            var request = new RestRequest("AuthUsers", Method.POST);
            AddAuthorizationHeader(request, ApiKey);

            request.AddJsonBody(addAuthUserArgument);

            return RestClient.Execute<CreatedAuthUser>(request);
        }
    }
}