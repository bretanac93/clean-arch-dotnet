using MediatR;
using VinylStore.Application.Commands;
using VinylStore.Domain.Entities;
using VinylStore.Domain.Repositories;
using VinylStore.Domain.Security;

namespace VinylStore.Application.Handlers;

public class RegisterCustomerHandler : IRequestHandler<RegisterCustomerCommand, Customer>
{
    private readonly CustomerRepository _customerRepository;
    private readonly PasswordHasher _passwordHasher;

    public RegisterCustomerHandler(CustomerRepository customerRepository, PasswordHasher passwordHasher)
    {
        _customerRepository = customerRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Customer> Handle(RegisterCustomerCommand command, CancellationToken cancellationToken)
    {
        var existingCustomer = await _customerRepository.GetByEmail(command.Email);
        if (existingCustomer is not null)
        {
            throw new ArgumentException("Email already in use");
        }

        var hashedPassword = _passwordHasher.HashPassword(command.Password);
        var customer = new Customer(command.Id, command.FirstName, command.LastName, command.Email, hashedPassword);

        await _customerRepository.Add(customer);

        return customer;
    }
}