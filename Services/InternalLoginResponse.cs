using Microsoft.AspNetCore.Authentication.BearerToken;

namespace IPS_survey.Services
{
    public class InternalLoginResponse
    {
        public AccessTokenResponse? AccessToken { get; set; }
    }
}