namespace VinylStore.Domain.Security;

public interface TokenGenerator
{
    string Generate(string id, string email);
}