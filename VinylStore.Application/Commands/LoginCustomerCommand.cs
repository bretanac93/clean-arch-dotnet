using MediatR;
using VinylStore.Application.Models;

namespace VinylStore.Application.Commands;

public record LoginCustomerCommand(string Email, string Password) : IRequest<AuthorizationBadge>;
