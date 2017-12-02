using System;
using PicnicAuthNetClient.Models;
using RestSharp;

namespace PicnicAuthNetClient.Interfaces
{
    public interface IPicnicAuthClient
    {
        IRestResponse<TokenResponse> Login(string username, string password);
        IRestResponse<AuthUsersInCompany> GetAuthUsers(int page = 1, int pageCount = 10);
        IRestResponse<CreatedAuthUser> AddAuthUser(AddAuthUserArgument addAuthUserArgument);
        IRestResponse<CreatedAuthUser> GenereteNewSecret(Guid userId);
        IRestResponse<LoggedCompany> GetLoggedCompany();
        IRestResponse<IdentityResult> AddCompany(AddCompanyArgument addCompanyArgument);
        IRestResponse<OneTimePassword> GetHotpForAuthUser(Guid userId);
        IRestResponse<OtpValidationResult> ValidateHotpForAuthUser(Guid userId, string hotp);
        IRestResponse<OneTimePassword> GetTotpForAuthUser(Guid userId);
        IRestResponse<OtpValidationResult> ValidateTotpForAuthUser(Guid userId, string totp);
    }
}