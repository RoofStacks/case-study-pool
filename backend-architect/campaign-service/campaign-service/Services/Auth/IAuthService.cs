namespace campaign_service.Services.Auth
{
    public interface IAuthService
    {
          string Authenticate(string username, string password);
    }
}