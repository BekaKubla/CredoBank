namespace KredoBank.Application.Services.JWTService
{
    public interface IJwtService
    {
        string GenerateUserToken(string userName, int id);
    }
}
