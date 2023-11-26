using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PCT.Domain.Account.Dtos;
using PCT.WebAPI.Controllers.Account;

namespace PCT.WebAPI.UnitTest;

public class AccountControllerTests
{
    private readonly AccountController _accountController;
    private readonly Mock<IMediator> _mediatorMock;

    public AccountControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _accountController = new AccountController(_mediatorMock.Object);
    }

    [Fact]
    public async Task Register_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var registerUserRequest = new RegisterUserRequest("okan@okan.com", "q1w2E3@!");
        var cancellationToken = CancellationToken.None;
        var expectedResponse = new RegisterUserResponse();
        _mediatorMock.Setup(m => m.Send(registerUserRequest, cancellationToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _accountController.Register(registerUserRequest, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Same(expectedResponse, okResult.Value);
    }

    [Fact]
    public async Task GetAll_AuthorizedUser_ReturnsOkResult()
    {
        // Arrange
        var cancellationToken = CancellationToken.None;
        var expectedResponse = new List<GetAllUserResponse>();
        _mediatorMock.Setup(m => m.Send(It.IsAny<GetAllUserRequest>(), cancellationToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _accountController.GetAll(cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Same(expectedResponse, okResult.Value);
    }

    [Fact]
    public async Task Login_ValidRequest_ReturnsOkResult()
    {
        // Arrange
        var loginUserRequest = new LoginUserRequest("okan.cilingiroglu@gmail.com", "password");
        var cancellationToken = CancellationToken.None;
        var expectedResponse = new LoginUserResponse();
        _mediatorMock.Setup(m => m.Send(loginUserRequest, cancellationToken))
            .ReturnsAsync(expectedResponse);

        // Act
        var result = await _accountController.Login(loginUserRequest, cancellationToken);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        Assert.Same(expectedResponse, okResult.Value);
    }
}