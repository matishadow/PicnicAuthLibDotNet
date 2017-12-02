using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    public abstract class AuthorizedEndpoint
    {
        private const string AuthenticationHeaderName = "Authorization";
        private const string AuthenticationHeaderValueFormat = "Bearer {0}";

        protected void AddAuthorizationHeader(IRestRequest request, string apiKey)
        {
            request?.AddHeader(AuthenticationHeaderName, string.Format(AuthenticationHeaderValueFormat, apiKey));
        }
    }
}