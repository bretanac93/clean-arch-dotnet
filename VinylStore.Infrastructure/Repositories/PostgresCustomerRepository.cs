using Microsoft.EntityFrameworkCore;
using VinylStore.Domain.Entities;
using VinylStore.Domain.Repositories;

namespace VinylStore.Infrastructure.Repositories;

public class PostgresCustomerRepository : CustomerRepository
{
    private readonly AppDbContext _context;

    public PostgresCustomerRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<Customer?> GetById(Guid id)
    {
        return _context.Customers.FindAsync(id).AsTask();
    }

    public Task<Customer?> GetByEmail(string email)
    {
        return _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
    }

    public async Task Add(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
        await _context.SaveChangesAsync();
    }
}