using VinylStore.Domain.Security;

namespace VinylStore.Infrastructure.Security;

public class DummyTokenGenerator : TokenGenerator
{
    public string Generate(string id, string email)
    {
        return $"{id}:{email}";
    }
}
