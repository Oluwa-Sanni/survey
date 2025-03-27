
public class ApplicationSettings
{
    public EmailAccount? emailAccount { get; set; }
    public string? ClientId { get; set; }
    public string? ApiKey { get; set; }
    public string AuthenticatedPassword { get; set; }
}

public class EmailAccount
{
    public string? ClientAdminEmail { get; set; }
    public string? EmailUrl { get; set; }
    public string? Password { get; set; }
    public string? IdentityUrl { get; set; }
    public string? Username { get; set; }
}