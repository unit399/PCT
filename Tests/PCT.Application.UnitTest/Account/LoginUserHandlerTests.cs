using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;
using PCT.Application.Account.Commands;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;
using PCT.Domain.Common.Enums;

namespace PCT.Application.UnitTest.Account;

public class LoginUserHandlerTests
{
    private readonly Mock<IConfiguration> _configurationMock;
    private readonly LoginUserHandler _loginUserHandler;
    private readonly Mock<UserManager<User>> _userManagerMock;

    public LoginUserHandlerTests()
    {
        _userManagerMock =
            new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        _configurationMock = new Mock<IConfiguration>();
        _loginUserHandler = new LoginUserHandler(_userManagerMock.Object, _configurationMock.Object);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsLoginUserResponseWithToken()
    {
        // Arrange
        var loginUserRequest = new LoginUserRequest("test@example.com", "q1w2E3@!");

        var user = new User
        {
            Email = loginUserRequest.Email
        };

        _userManagerMock.Setup(m => m.FindByEmailAsync(loginUserRequest.Email))
            .ReturnsAsync(user);

        _userManagerMock.Setup(m => m.CheckPasswordAsync(user, loginUserRequest.Password))
            .ReturnsAsync(true);

        _userManagerMock.Setup(m => m.GetRolesAsync(user))
            .ReturnsAsync(new List<string> { "Coach" });

        _configurationMock.Setup(c => c["JWT:Secret"])
            .Returns("test-secret-ThisIsMySecretKey123456789");

        _configurationMock.Setup(c => c["JWT:ValidIssuer"])
            .Returns("test-issuer");

        _configurationMock.Setup(c => c["JWT:ValidAudience"])
            .Returns("test-audience");

        // Act
        var result = await _loginUserHandler.Handle(loginUserRequest, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodeType.Success, result.StatusCode.Type);
        Assert.Equal("Login completed successfully", result.StatusCode.Message);
        Assert.NotNull(result.Token);

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.ReadJwtToken(result.Token);

        Assert.Equal("test-issuer", token.Issuer);
        Assert.Equal("test-audience", token.Audiences.First());
        Assert.True(token.ValidTo.AddHours(2) > DateTime.Now);
        Assert.True(token.Claims.Any(c => c.Type == ClaimTypes.Name && c.Value == user.Email));
        Assert.True(token.Claims.Any(c => c.Type == JwtRegisteredClaimNames.Jti));
        Assert.True(token.Claims.Any(c => c.Type == ClaimTypes.Role && c.Value == "Coach"));
    }

    [Fact]
    public async Task Handle_InvalidRequest_ReturnsLoginUserResponseWithError()
    {
        // Arrange
        var loginUserRequest = new LoginUserRequest("test@example.com", "q1w2E3@!");

        _userManagerMock.Setup(m => m.FindByEmailAsync(loginUserRequest.Email))
            .ReturnsAsync((User)null!);

        // Act
        var result = await _loginUserHandler.Handle(loginUserRequest, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodeType.Error, result.StatusCode.Type);
        Assert.Equal("Login Failed", result.StatusCode.Message);
        Assert.Null(result.Token);
    }

    [Fact]
    public async Task Handle_InvalidPassword_ReturnsLoginUserResponseWithError()
    {
        // Arrange
        var loginUserRequest = new LoginUserRequest("test@example.com", "q1w2E3@!");

        var user = new User
        {
            Email = loginUserRequest.Email
        };

        _userManagerMock.Setup(m => m.FindByEmailAsync(loginUserRequest.Email))
            .ReturnsAsync(user);

        _userManagerMock.Setup(m => m.CheckPasswordAsync(user, loginUserRequest.Password))
            .ReturnsAsync(false);

        // Act
        var result = await _loginUserHandler.Handle(loginUserRequest, CancellationToken.None);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(StatusCodeType.Error, result.StatusCode.Type);
        Assert.Equal("Login Failed", result.StatusCode.Message);
        Assert.Null(result.Token);
    }
}