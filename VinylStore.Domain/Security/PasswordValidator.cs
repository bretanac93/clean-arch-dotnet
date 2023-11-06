namespace VinylStore.Domain.Security;

public interface PasswordValidator
{
    bool IsValid(string plainTextPassword, string hashedPassword);
}