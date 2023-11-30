using MediatR;
using Microsoft.AspNetCore.Identity;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;
using PCT.Domain.Common.Entities;
using PCT.Domain.Common.Enums;

namespace PCT.Application.Account.Commands;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserRequest, RegisterUserResponse>
{
    private readonly UserManager<User> _userManager;

    public RegisterUserHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task<RegisterUserResponse> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
    {
        var userExist = await _userManager.FindByEmailAsync(request.Email);
        if (userExist != null)
            return new RegisterUserResponse
            {
                StatusCode = new StatusCode { Type = StatusCodeType.Error, Message = "User Already Exist" }
            };

        var user = new User
        {
            UserName = request.Email,
            Email = request.Email,
            SecurityStamp = Guid.NewGuid().ToString()
        };

        var result = await _userManager.CreateAsync(user, request.Password);

        if (!result.Succeeded)
            return new RegisterUserResponse
            {
                StatusCode = new StatusCode { Type = StatusCodeType.Error, Message = result.Errors.First().Description }
            };

        await _userManager.AddToRoleAsync(user, UserRoles.Coach);

        return new RegisterUserResponse
        {
            Email = user.Email,
            Id = Guid.Parse(user.Id),
            StatusCode = new StatusCode
            {
                Type = StatusCodeType.Success, Message = "Registration completed successfully"
            }
        };
    }
}