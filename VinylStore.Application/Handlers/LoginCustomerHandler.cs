using System.Security.Authentication;
using MediatR;
using VinylStore.Application.Commands;
using VinylStore.Application.Models;
using VinylStore.Domain.Repositories;
using VinylStore.Domain.Security;

namespace VinylStore.Application.Handlers;

public class LoginCustomerHandler : IRequestHandler<LoginCustomerCommand, AuthorizationBadge>
{
    private readonly CustomerRepository _customerRepository;
    private readonly PasswordValidator _passwordValidator;
    private readonly TokenGenerator _tokenGenerator;

    public LoginCustomerHandler(CustomerRepository customerRepository, PasswordValidator passwordValidator,
        TokenGenerator tokenGenerator)
    {
        _customerRepository = customerRepository;
        _passwordValidator = passwordValidator;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<AuthorizationBadge> Handle(LoginCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByEmail(request.Email);

        var invalidCredentials = customer is null ||
                               !_passwordValidator.IsValid(request.Password, customer.PasswordHash);

        if (invalidCredentials)
        {
            // artificial throttle to avoid rapid brute force attacks.
            await Task.Delay(1000, cancellationToken);
            throw new AuthenticationException("Invalid email or password");
        }

        var token = _tokenGenerator.Generate(customer!.Id.ToString(), customer.Email);

        return new AuthorizationBadge(Token: token, Email: customer.Email);
    }
}