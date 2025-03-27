namespace IPS_survey.Services
{
    public interface IIdentityAdapter
    {
        Task<string?> FetchToken(InternalLoginRequest request,
            CancellationToken ctx);
    }

    public class InternalLoginRequest
    {
        public string? Password { get; set; }
        public string? EmailAddress { get; set; }
        public string? SenderApplicationName { get; set; } = "ONBOARDING PORTAL";
    }
}
