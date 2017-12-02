using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    public abstract class AuthorizedEndpoint : RestEndpoint
    {
        private const string AuthenticationHeaderName = "Authorization";
        private const string AuthenticationHeaderValueFormat = "Bearer {0}";

        protected void AddAuthorizationHeader(IRestRequest request, string apiKey)
        {
            request?.AddHeader(AuthenticationHeaderName, string.Format(AuthenticationHeaderValueFormat, apiKey));
        }

        protected AuthorizedEndpoint(IRestClient restClient, string apiKey) : base(restClient, apiKey)
        {
        }
    }
}