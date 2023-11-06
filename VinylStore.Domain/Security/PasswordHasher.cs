namespace VinylStore.Domain.Security;

public interface PasswordHasher
{
    string HashPassword(string plainTextPassword);
}
