using VinylStore.Domain.Security;

namespace VinylStore.Infrastructure.Security;

public class BCryptPasswordService : PasswordValidator, PasswordHasher
{
    public bool IsValid(string plainTextPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainTextPassword, hashedPassword);
    }

    public string HashPassword(string plainTextPassword)
    {
        return BCrypt.Net.BCrypt.HashPassword(plainTextPassword);
    }
}