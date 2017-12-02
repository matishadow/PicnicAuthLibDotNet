using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    internal class CompaniesEndpoint : AuthorizedEndpoint
    {
        public CompaniesEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }

        public IRestResponse<LoggedCompany> GetLoggedCompany()
        {
            var request = new RestRequest("Companies/Me", Method.GET);
            AddAuthorizationHeader(request, ApiKey);

            return RestClient.Execute<LoggedCompany>(request);
        }

        public IRestResponse<IdentityResult> AddCompany(AddCompanyArgument addCompanyArgument)
        {
            var request = new RestRequest("Companies", Method.POST);
            AddAuthorizationHeader(request, ApiKey);

            request.AddJsonBody(addCompanyArgument);

            return RestClient.Execute<IdentityResult>(request);
        }
    }
}