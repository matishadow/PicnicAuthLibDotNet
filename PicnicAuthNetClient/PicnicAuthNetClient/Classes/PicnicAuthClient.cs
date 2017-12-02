using System;
using PicnicAuthNetClient.Classes.Endpoints;
using PicnicAuthNetClient.Interfaces;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Classes
{
    public class PicnicAuthClient : IPicnicAuthClient
    {
        private readonly IRestClient restClient;
        private string apiKey;

        private AuthUsersEndpoint authUsersEndpoint;
        private AuthUsersSecretsEndpoint authUsersSecretsEndpoint;
        private CompaniesEndpoint companiesEndpoint;
        private HotpsEndpoint hotpsEndpoint;
        private TotpsEndpoint totpsEndpoint;
        private TokensEndpoint tokensEndpoint;

        public PicnicAuthClient(Uri baseEndpoint, string apiKey)
        {
            restClient = new RestClient(baseEndpoint);
            this.apiKey = apiKey;
            CreateEndpoints();
        }

        private void CreateEndpoints()
        {
            authUsersEndpoint = new AuthUsersEndpoint(restClient, apiKey);
            authUsersSecretsEndpoint = new AuthUsersSecretsEndpoint(restClient, apiKey);
            companiesEndpoint = new CompaniesEndpoint(restClient, apiKey);
            hotpsEndpoint = new HotpsEndpoint(restClient, apiKey);
            totpsEndpoint = new TotpsEndpoint(restClient, apiKey);
            tokensEndpoint = new TokensEndpoint(restClient);
        }

        public IRestResponse<TokenResponse> Login(string username, string password)
        {
            IRestResponse<TokenResponse> response = tokensEndpoint.GetApiKey(username, password);
            apiKey = response.Data.access_token;
            CreateEndpoints();

            return response;
        }

        public IRestResponse<AuthUsersInCompany> GetAuthUsers(int page = 1, int pageCount = 10)
        {
            return authUsersEndpoint.GetAuthUsersForLoggedCompany(page, pageCount);
        }

        public IRestResponse<CreatedAuthUser> AddAuthUser(AddAuthUserArgument addAuthUserArgument)
        {
            return authUsersEndpoint.AddAuthUser(addAuthUserArgument);
        }

        public IRestResponse<CreatedAuthUser> GenereteNewSecret(Guid userId)
        {
            return authUsersSecretsEndpoint.GenereteNewSecret(userId);
        }

        public IRestResponse<LoggedCompany> GetLoggedCompany()
        {
            return companiesEndpoint.GetLoggedCompany();
        }

        public IRestResponse<IdentityResult> AddCompany(AddCompanyArgument addCompanyArgument)
        {
            return companiesEndpoint.AddCompany(addCompanyArgument);
        }

        public IRestResponse<OneTimePassword> GetHotpForAuthUser(Guid userId)
        {
            return hotpsEndpoint.GetHotpForAuthUser(userId);
        }

        public IRestResponse<OtpValidationResult> ValidateHotpForAuthUser(Guid userId, string hotp)
        {
            return hotpsEndpoint.ValidateHotpForAuthUser(userId, hotp);
        }

        public IRestResponse<OneTimePassword> GetTotpForAuthUser(Guid userId)
        {
            return totpsEndpoint.GetTotpForAuthUser(userId);
        }

        public IRestResponse<OtpValidationResult> ValidateTotpForAuthUser(Guid userId, string totp)
        {
            return totpsEndpoint.ValidateTotpForAuthUser(userId, totp);
        }
    }
}