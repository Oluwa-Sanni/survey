using IPS_survey.models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Json;
using System.Text;

namespace IPS_survey.Services
{
    public class IdentityAdapter : IIdentityAdapter
    {
        private readonly ApplicationSettings appSettings;
        private readonly IHttpClientFactory httpClientFactory;
        private readonly ILoggerManager _logger;
        private readonly IMemoryCache memoryCache;
        public IdentityAdapter(IOptions<ApplicationSettings> appSettings, IHttpClientFactory httpClientFactory,
            ILoggerManager logger, IMemoryCache memoryCache)
        {
            this.appSettings = appSettings.Value;
            this.httpClientFactory = httpClientFactory;
            this._logger = logger;
            this.memoryCache = memoryCache;
        }
        public async Task<string?> FetchToken(InternalLoginRequest request,
            CancellationToken ctx)
        {
            string? token = string.Empty;
            try
            {
                if (memoryCache.TryGetValue("FetchTokenFromIdentity", out token))
                    return token;
                DateTime utcTimestamp = DateTime.UtcNow;
                string? xtoken = UtilityService.GenerateAsymptoticHash(utcTimestamp,
                    appSettings.AuthenticatedPassword ?? "", appSettings.ClientId ?? "");
                HttpRequestMessage requestMessage = new(HttpMethod.Post, "Authentication/Login")
                {
                    Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, Application.Json),
                    Headers =
                {
                    {"X-Api-Key",appSettings.ApiKey??"" },
                    {"X-Client-Id", appSettings.ClientId ?? ""},
                    {"X-TimeStamp", utcTimestamp.ToString()},
                    {"X-Seed-Id", xtoken}
                }
                };
                var httpClient = httpClientFactory.CreateClient("IdentityConfig");
                using var httpResponseMessage = await httpClient.SendAsync(requestMessage, ctx);
                string contentStream = await httpResponseMessage.Content.ReadAsStringAsync(ctx);
                Response<InternalLoginResponse>? loginResponse = JsonSerializer
                    .Deserialize<Response<InternalLoginResponse>>(contentStream,
                    UtilityService.SharedOptions);
                _logger.LogInfo($"Access token for request: {request.EmailAddress} returned: {contentStream}");
                if (loginResponse is not null && loginResponse.Successful &&
                    loginResponse.Result is not null && loginResponse.Result.AccessToken is not null
                    && !string.IsNullOrEmpty(loginResponse.Result.AccessToken.AccessToken))
                {
                    token = loginResponse.Result.AccessToken.AccessToken;
                    memoryCache.Set("FetchTokenFromIdentity", token, TimeSpan.FromMinutes(4));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
                _logger.LogError($"An error occured fetching token {ex.Message}");
            }
            return token;
        }
    }
}
