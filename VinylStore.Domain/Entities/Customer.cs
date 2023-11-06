namespace VinylStore.Domain.Entities;

public record Customer(Guid Id, string FirstName, string LastName, string Email, string PasswordHash)
{
    public string FullName => $"{FirstName} {LastName}";
}
