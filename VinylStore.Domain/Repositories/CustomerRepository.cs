using VinylStore.Domain.Entities;

namespace VinylStore.Domain.Repositories;

public interface CustomerRepository
{
    Task<Customer?> GetById(Guid id);
    Task<Customer?> GetByEmail(string email);
    Task Add(Customer customer);
}
