namespace Plurish.Auth.Domain.Services;
public interface ITwoFactorService
{
    string GenerateCode();
    bool VerifyCode(string providedCode, string expectedCode);
}

