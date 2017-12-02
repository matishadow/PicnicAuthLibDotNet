using RestSharp;

namespace PicnicAuthNetClient.Classes.Endpoints
{
    public class RestEndpoint
    {
        protected readonly IRestClient RestClient;
        protected readonly string ApiKey;

        protected RestEndpoint(IRestClient restClient, string apiKey)
        {
            this.RestClient = restClient;
            this.ApiKey = apiKey;
        }
    }
}