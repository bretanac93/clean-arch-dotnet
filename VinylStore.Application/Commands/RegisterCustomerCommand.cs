using MediatR;
using VinylStore.Domain.Entities;

namespace VinylStore.Application.Commands;

public record RegisterCustomerCommand
    (Guid Id, string FirstName, string LastName, string Email, string Password) : IRequest<Customer>;