namespace HoPe.Core.Service
{
    public interface IAuthService
    {
        string GenerateToken(string user, string role);
        string ComputeSha256(string passWord);
    }
}
