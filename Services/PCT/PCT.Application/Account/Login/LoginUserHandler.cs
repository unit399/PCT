using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PCT.Domain.Account;
using PCT.Domain.Common.Entity;
using PCT.Domain.Common.Enum;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace PCT.Application.Account.Login;

public sealed class LoginUserHandler: IRequestHandler<LoginUserRequest, LoginUserResponse>
{
    private readonly UserManager<User> _userManager;
    private readonly IConfiguration _configuration;

    public LoginUserHandler(UserManager<User> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    
    public async Task<LoginUserResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.Email);
        if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,user.Email!),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            
            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            
            var authSignInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]!));
            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(120),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSignInKey, SecurityAlgorithms.HmacSha256)
            );
            
            return new LoginUserResponse
            {
                StatusCode = new StatusCode
                {
                    Type = StatusCodeType.Success, Message = "Login completed successfully"
                },
                Token = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

        return new LoginUserResponse
        {
            StatusCode = new StatusCode
            {
                Type = StatusCodeType.Error, Message = "Login Failed"
            }
        };
    }
}