﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Users.Command.AssignUserRole;
using Restaurants.Application.Users.Command.UnassignUserRole;
using Restaurants.Application.Users.Command.UpdateUserDetails;
using Restaurants.Domain.Constants;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/identity")]
public class IdentityController(IMediator mediator) : ControllerBase
{
    [HttpPatch("user")]
    [Authorize]
    public async Task<IActionResult> UpdateUser(UpdateUserDetailsCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

    [HttpPost("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> AssignUserRole(AssignUserRoleCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("userRole")]
    [Authorize(Roles = UserRoles.Admin)]
    public async Task<IActionResult> DeleteUserRole(UnassignUserRoleCommand command)
    {
        await mediator.Send(command);

        return NoContent();
    }

}
