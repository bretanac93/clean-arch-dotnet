using MediatR;
using Microsoft.AspNetCore.Mvc;
using VinylStore.Application.Commands;

namespace VinylStore.Api.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterCustomer(RegisterCustomerCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(RegisterCustomer), result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> LoginCustomer(LoginCustomerCommand command)
    {
        try
        {
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(LoginCustomer), result);
        }
        catch (Exception e)
        {
            return BadRequest(new { message = e.Message });
        }
    }
}
