﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;

namespace Restaurants.Application.Users.Command.UnassignUserRole;
public class UnassignUserRoleCommandHandler(ILogger<UnassignUserRoleCommandHandler> logger,
    UserManager<ApplicationUser> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnassignUserRoleCommand>
{
    public async Task Handle(UnassignUserRoleCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Unassigning user role: {@Request}", request);


        var user = await userManager.FindByEmailAsync(request.UserEmail)
            ?? throw new NotFoundException(nameof(ApplicationUser), request.UserEmail);

        var role = await roleManager.FindByNameAsync(request.RoleName)
            ?? throw new NotFoundException(nameof(IdentityRole), request.RoleName);

        await userManager.RemoveFromRoleAsync(user, role.Name!);
    }
}
