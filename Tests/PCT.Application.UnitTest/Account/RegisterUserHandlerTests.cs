using Microsoft.AspNetCore.Identity;
using Moq;
using PCT.Application.Account.Commands;
using PCT.Domain.Account.Dtos;
using PCT.Domain.Account.Entities;
using PCT.Domain.Common.Enums;

namespace PCT.Application.UnitTest.Account;

public class RegisterUserHandlerTests
{
    private readonly RegisterUserHandler _registerUserHandler;
    private readonly Mock<UserManager<User>> _userManagerMock;

    public RegisterUserHandlerTests()
    {
        _userManagerMock =
            new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);
        _registerUserHandler = new RegisterUserHandler(_userManagerMock.Object);
    }

    [Fact]
    public async Task Handle_WithNewUser_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new RegisterUserRequest("test@example.com", "q1w2E3@!");

        var createUserResult = IdentityResult.Success;

        _userManagerMock.Setup(m => m.FindByEmailAsync(request.Email))
            .ReturnsAsync((User)null!);

        _userManagerMock.Setup(m => m.CreateAsync(It.IsAny<User>(), request.Password))
            .ReturnsAsync(createUserResult)
            .Verifiable();

        _userManagerMock.Setup(m => m.AddToRoleAsync(It.IsAny<User>(), UserRoles.Coach))
            .ReturnsAsync(IdentityResult.Success)
            .Verifiable();

        // Act
        var response = await _registerUserHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(request.Email, response.Email);
        Assert.Equal(StatusCodeType.Success, response.StatusCode.Type);
        Assert.Equal("Registration completed successfully", response.StatusCode.Message);
    }

    [Fact]
    public async Task Handle_WithExistingUser_ReturnsErrorResponse()
    {
        // Arrange
        var request = new RegisterUserRequest("test@example.com", "q1w2E3@!");

        var existingUser = new User();

        _userManagerMock.Setup(m => m.FindByEmailAsync(request.Email))
            .ReturnsAsync(existingUser);

        // Act
        var response = await _registerUserHandler.Handle(request, CancellationToken.None);

        // Assert
        Assert.Equal(StatusCodeType.Error, response.StatusCode.Type);
        Assert.Equal("User Already Exist", response.StatusCode.Message);
    }
}